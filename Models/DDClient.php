<?php
/**
 * 用户的SDK先写一个大类，再抽
 * @author    sizzflair
 * @datetime  2013/3/5
 * @modify    2012/3/5
 * @copyright Copyright (c) 2012 Wuhan Bo Sheng Education Information Co., Ltd.
 * @version 0.1
 */
/**
 * 线上的配置
 * APP_ID:49
 * APP_KEY:65c4157fa78e014fe3e67e587806d177
 * APP_SECRET:d32f2d676e09de33
 */
//header('Content-Type: text/html; charset=UTF-8');
/*站内应用生成的APPID*/
define( "DD_APPID" , '54' );
/*APP_KEY*/
define( "DD_AKEY" , '822c8d5c0be6c06f51b82b4156c2a7d6' );
/*APP_SERCET*/
define( "DD_SKEY" , 'b0eaaa2600021242' );
/*回调地址，这个不是已经写过去了么,估计是未授权就跳，但是可能是多此一举*/
define( "DD_CALLBACK_URL" , 'http://172.16.3.10/xue/callback.php');
/*多多社区API地址*/
define( "DD_API_URL" , 'http://dev.dodoedu.com/DDApi/');


/**
 * 社区站内应用的PHP SDK
 */
class Models_DDClient{

    private $appId = '';
    private $appKey = '';
    private $appSecret = '';
    private $callBackUrl = '';
    private $accessToken = '';
    private $refreshToken = '';

    public $http_code;
    /**
     * Contains the last API call.
     *
     * @ignore
     */
    public $url;
    /**
     * Set up the API root URL.
     *
     * @ignore
     */
    public $host = DD_API_URL;
    /**
     * Set timeout default.
     *
     * @ignore
     */
    public $timeout = 30;
    /**
     * Set connect timeout.
     *
     * @ignore
     */
    public $connecttimeout = 30;
    /**
     * Verify SSL Cert.
     *
     * @ignore
     */
    public $ssl_verifypeer = FALSE;
    /**
     * Respons format.
     *
     * @ignore
     */
    public $format = 'json';
    /**
     * Decode returned json data.
     *
     * @ignore
     */
    public $decode_json = TRUE;
    /**
     * Contains the last HTTP headers returned.
     *
     * @ignore
     */
    public $http_info;
    /**
     * Set the useragnet.
     *
     * @ignore
     */
    public $useragent = 'DDApi';

    /**
     * print the debug info
     *
     * @ignore
     */
    public $debug = FALSE;

    /**
     * boundary of multipart
     * @ignore
     */
    public static $boundary = '';

    /**
     * params of file
     * @ignore
     */



    /**
     * 构造函数
     */

    function __construct($access_token = NULL, $refresh_token = NULL)
    {
        $this->appId = DD_APPID;
        $this->appKey = DD_AKEY;
        $this->appSecret = DD_SKEY;
        $this->callBackUrl = DD_CALLBACK_URL;
        $this->accessToken = $access_token;
        $this->refreshToken = $refresh_token;

    }

    /**
     * 获取认证连接
     * @ignore
     */
    private function _grantAuthorizeURL()
    { 
        return DD_API_URL.'auth/authorize/';
    }

    /**
     * 请求accessToken的地址
     * @ignore
     */
    private function _grantAccessTokenURL()
    {
        return DD_API_URL.'auth/accesstoken/';
    }



    /**
     * 处理服务器传过来的POST
     * @param $signedRequest
     * @return -1,签名算法不对应. -2,客户端签名与从服务器传过来的不一致.没有错误的话返回数组
     */

    public function parseSignedRequest($signedRequest)
    {
        list($sig, $requestUrl) = explode('.', $signedRequest, 2);
        $infoArr = base64_decode($requestUrl);
        $infoArr = json_decode($infoArr);
        $clientSig = base64_encode(hash_hmac('sha256', $infoArr->user_id, DD_SKEY, true));
        if($infoArr->algorithm != 'HMAC-SHA256' ){
            return '-1';
        }else if($clientSig != $sig ){
            return '-2';
        }else{
            return $this->json_to_array($infoArr);
        }
    }


    /**
     * 获得用户的基本资料http请求
     */
    public function getUserInfo($accessToken,$refreshToken)
    {
        $infoUrl = DD_API_URL.'user/base/?access_token='.$accessToken.'&refresh_token='.$refreshToken;
        $infoData  = file_get_contents($infoUrl);
        if(isset(json_decode($infoData)->errorCode) AND json_decode($infoData)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->getUserInfo($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token']);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($infoData));
            return $infoData;
        }
    }

    /**
     * 获得用户的基本资料curl请求
     * @param $accessToken
     * @param $refreshToken
     * @return array
     */
    public function getUserInfoCurl($accessToken,$refreshToken)
    {
        $params = array();
        $params['access_token'] = $accessToken;
//        $params['refresh_token'] = $refreshToken;
        $response = $this->oAuthRequest(DD_API_URL.'user/base/', 'POST', $params);
        if(isset(json_decode($response)->errorCode) AND json_decode($response)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->getUserInfoCurl($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token']);
                //return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $response;
            //return $infoData;
        }
        $data_arr = json_decode($infoData,1);
        return $data_arr['data'];
        
        
    }


    /**
     * 获得用户的全部资料http请求
     */
    public function getUserCompleteInfo($accessToken,$refreshToken)
    {
        $infoUrl = DD_API_URL.'user/complete/?access_token='.$accessToken.'&refresh_token='.$refreshToken;
        $infoData  = file_get_contents($infoUrl);
        if(isset(json_decode($infoData)->errorCode) AND json_decode($infoData)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->getUserCompleteInfo($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token']);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($infoData));
            return $infoData['data'];
        }
    }


    /**
     * 获得用户详细资料curl
     * @param $accessToken
     * @param $refreshToken
     * @return array
     */
    public function getUserCompleteInfoCurl($accessToken,$refreshToken){
        $params = array();
        $params['access_token'] = $accessToken;
        $params['refresh_token'] = $refreshToken;
        $response = $this->oAuthRequest(DD_API_URL.'user/complete/', 'POST', $params);
        if(isset(json_decode($response)->errorCode) AND json_decode($response)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->getUserCompleteInfoCurl($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token']);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($response));
            return $infoData['data'];
        }
        
    }


    /**
     * 获取用户绑定的翼学通号码
     */
    public function getUserEStudyNumber($accessToken,$refreshToken)
    {
        $infoUrl = DD_API_URL.'user/estudynumber/?access_token='.$accessToken.'&refresh_token='.$refreshToken;
        echo $infoUrl;
        $infoData  = file_get_contents($infoUrl);
        if(isset(json_decode($infoData)->errorCode) AND json_decode($infoData)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->getUserEStudyNumber($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token']);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($infoData));
            return $infoData['data'];
        }
    }



    /**
     * 推送消息的接口
     * @param $accessToken
     * @param $refreshToken
     * @param $message
     * @return array|string
     */
    public function putMessage($accessToken,$refreshToken,$message,array $targetArray)
    {
        $infoUrl = DD_API_URL.'message/message/?access_token='.$accessToken.'&refresh_token='.$refreshToken.'&message='.$message.'&target='.json_encode($targetArray);
        $infoData  = file_get_contents($infoUrl);
        echo $infoUrl;
        if(isset(json_decode($infoData)->errorCode) AND json_decode($infoData)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->putMessage($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token'],$message,$targetArray);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($infoData));
            return $infoData['data'];
        }
    }

    /**
     * 推送消息给社区用户
     * @param $accessToken
     * @param $refreshToken
     * @param $message
     * @param array $targetArray
     */
    public function putMessageCurl($accessToken,$refreshToken,$message,array $targetArray)
    {
        $params = array();
        $params['access_token'] = $accessToken;
//        $params['refresh_token'] = $refreshToken;
        $params['message'] = $message;
        $params['target'] = json_encode($targetArray);
        $response = $this->oAuthRequest(DD_API_URL.'message/message/', 'POST', $params);
        if(isset(json_decode($response)->errorCode) AND json_decode($response)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->putMessageCurl($_SESSION['oauth_access_token'],$_SESSION['oauth_refresh_token'],$message,$targetArray);
                return $infoData;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($response));
            return $infoData['data'];
        }
    }




    /**
     * 使用refresh_token换取新的access_token
     * @param $accessToken
     * @param $refreshToken
     * @return bool
     */
    public function _grantNewAccessToken($accessToken,$refreshToken){
        if(!$accessToken and !$refreshToken){
            return false;
        }
        $infoUrl = DD_API_URL.'auth/newaccesstoken/?access_token='.$accessToken.'&refresh_token='.$refreshToken;
//        $infoData  = file_get_contents($infoUrl);
        $params = array();
        $params['access_token'] = $accessToken;
        $params['refresh_token'] = $refreshToken;
        $response = $this->oAuthRequest(DD_API_URL.'/auth/newaccesstoken/', 'POST', $params);
        $infoData = json_decode($response);
        if(isset($infoData->errorCode)){
            return false;
        }else{
            $_SESSION['tokens']['accessToken'] = $infoData->accessToken;
            $_SESSION['tokens']['refreshToken'] = $infoData->refreshToken;
            return true;
        }
    }


    /**
     * authorize接口
     * 
     */
    public function getAuthorizeURL( $inUrl, $inResponseType = 'code', $inState = NULL, $inDisplay = NULL )
    {
        $params = array();
        $params['client_key'] = $this->appKey;
        $params['redirect_uri'] = $inUrl;
        $params['response_type'] = $inResponseType;
        $params['state'] = $inState;
        $params['display'] = $inDisplay;
        return $this->_grantAuthorizeURL() . "?" . http_build_query($params);
    }


    /**
     * access_token接口
     *
     * 对应API：{@link /DDApi/accessToken}
     *
     * @param string $type 请求的类型,可以为:code, password, token
     * @param array $keys 其他参数：(目前都固定为CODE)
     *  - 当$type为code时： array('code'=>..., 'redirect_uri'=>...)
     *  - 当$type为password时： array('username'=>..., 'password'=>...)
     *  - 当$type为token时： array('refresh_token'=>...)
     * @return array
     */
    public function getAccessToken( $type = 'code', $keys )
    {
        $params = array();
        $params['client_key'] = $this->appKey;
        $params['client_secret'] = $this->appSecret;
        if ( $type === 'code' ) {
            $params['grant_type'] = 'authorization_code';
            $params['code'] = $keys['code'];
            $params['redirect_uri'] = $keys['redirectUri'];
        }else {
            throw new OAuthException("wrong auth type");
        }
        $response = $this->oAuthRequest($this->_grantAccessTokenURL(), 'POST', $params);
        $token = json_decode($response, true);
        if ( is_array($token) && !isset($token['error']) ) {
            $this->accessToken = $token['accessToken'];
            $this->refreshToken = $token['refreshToken'];
        } else {
            throw new OAuthException("get access token failed." . $token['error']);
        }
        return $token;
    }






    /**
     * Format and sign an OAuth / API request
     *
     * @return string
     * @ignore
     */
    public function oAuthRequest($url, $method, $parameters, $multi = false)
    {

        switch ($method) {

            case 'POST':
                $headers = array();
//                $parameters['access_token'] = $this->accessToken;
                if (!$multi && (is_array($parameters) || is_object($parameters)) ) {
                    $body = http_build_query($parameters);
                } else {
                    $body = self::build_http_query_multi($parameters);
                    $headers[] = "Content-Type: multipart/form-data; boundary=" . self::$boundary;
                }
                return $this->http($url, $method, $body, $headers);
                break;
            default :
                echo "目前只支持post方法";
        }
    }

    /**
     * @ignore
     */
    public static function build_http_query_multi($params)
    {
        if (!$params) return '';

        uksort($params, 'strcmp');

        $pairs = array();

        self::$boundary = $boundary = uniqid('------------------');
        $MPboundary = '--'.$boundary;
        $endMPboundary = $MPboundary. '--';
        $multipartbody = '';

        foreach ($params as $parameter => $value) {
            if( in_array($parameter, self::$params_file) && $value{0} == '@' ) {
                $url = ltrim( $value, '@' );
                if(!empty($url))
                {
                    $content = file_get_contents( $url );
                    $array = explode( '?', basename( $url ) );
                    $filename = $array[0];

                    $filename = $_FILES[$parameter]['name'];
                    $multipartbody .= $MPboundary . "\r\n";
                    $mime = self::get_image_mime($url);
                    $multipartbody .= 'Content-Disposition: form-data; name="' . $parameter . '"; filename="' . $filename . '"'. "\r\n";
                    $multipartbody .= "Content-Type: ".$mime."\r\n\r\n";
                    $multipartbody .= $content. "\r\n";
                }
            } else {
                $multipartbody .= $MPboundary . "\r\n";
                $multipartbody .= 'content-disposition: form-data; name="' . $parameter . "\"\r\n\r\n";
                $multipartbody .= $value."\r\n";
            }

        }

        $multipartbody .= $endMPboundary;
        return $multipartbody;
    }



    /**
     * Make an HTTP request
     *
     * @return string API results
     * @ignore
     */
    public function http($url, $method, $postfields = NULL, $headers = array())
    {
        $this->http_info = array();
        $ci = curl_init();
        /* Curl settings */
        curl_setopt($ci, CURLOPT_HTTP_VERSION, CURL_HTTP_VERSION_1_0);
        curl_setopt($ci, CURLOPT_USERAGENT, $this->useragent);
        curl_setopt($ci, CURLOPT_CONNECTTIMEOUT, $this->connecttimeout);
        curl_setopt($ci, CURLOPT_TIMEOUT, $this->timeout);
        curl_setopt($ci, CURLOPT_RETURNTRANSFER, TRUE);
        curl_setopt($ci, CURLOPT_ENCODING, "");
        curl_setopt($ci, CURLOPT_SSL_VERIFYPEER, $this->ssl_verifypeer);
        curl_setopt($ci, CURLOPT_HEADERFUNCTION, array($this, 'getHeader'));
        curl_setopt($ci, CURLOPT_HEADER, FALSE);

        switch ($method) {
            case 'POST':
                curl_setopt($ci, CURLOPT_POST, TRUE);
                if (!empty($postfields)) {
                    curl_setopt($ci, CURLOPT_POSTFIELDS, $postfields);
                    $this->postdata = $postfields;
                }
                break;
            case 'DELETE':
                curl_setopt($ci, CURLOPT_CUSTOMREQUEST, 'DELETE');
                if (!empty($postfields)) {
                    $url = "{$url}?{$postfields}";
                }
        }

        if ( isset($this->accessToken) && $this->accessToken ) {
            $headers[] = "Authorization: OAuth2 ".$this->accessToken;
        }

        $headers[] = "API-RemoteIP: " . $_SERVER['REMOTE_ADDR'];
        curl_setopt($ci, CURLOPT_URL, $url );
        curl_setopt($ci, CURLOPT_HTTPHEADER, $headers );
        curl_setopt($ci, CURLINFO_HEADER_OUT, TRUE );
        $response = curl_exec($ci);
        $this->http_code = curl_getinfo($ci, CURLINFO_HTTP_CODE);
        $this->http_info = array_merge($this->http_info, curl_getinfo($ci));
        $this->url = $url;

        if ($this->debug) {
            echo "=====post data======\r\n";
            var_dump($postfields);

            echo '=====info====='."\r\n";
            print_r( curl_getinfo($ci) );

            echo '=====$response====='."\r\n";
            print_r( $response );
        }

        curl_close ($ci);
        return $response;
    }

    /**
     * Get the header info to store.
     *
     * @return int
     * @ignore
     */
    public function getHeader($ch, $header)
    {
        $i = strpos($header, ':');
        if (!empty($i)) {
            $key = str_replace('-', '_', strtolower(substr($header, 0, $i)));
            $value = trim(substr($header, $i + 2));
            $this->http_header[$key] = $value;
        }
        return strlen($header);
    }

    /**
     * 将JSON对象转化成ARRAY
     * @param $obj
     * @return array
     */
    public function json_to_array($obj){
        $arr=array();
        foreach((array)$obj as $k=>$w){
            if(is_object($w)) $arr[$k]=$this->json_to_array($w);  //判断类型是不是object
            else $arr[$k]=$w;
        }
        return $arr;
    }
    /**
     * 根据ID查找个人资料
     * @param $accessToken
     * @param $refreshToken
     * @param $userId
     */
    public function searchUserInfo($userId)
    {
        $tokens = $_SESSION['tokens'];
        $accessToken = $tokens['accessToken'];
        $refreshToken= $tokens['refreshToken'];
        $infoUrl = DD_API_URL.'user/searchuserinfo/?access_token='.$accessToken.'&refresh_token='.$refreshToken.'&user_id='.$userId;
        $infoData = file_get_contents($infoUrl);
        if(isset(json_decode($infoData)->errorCode) AND json_decode($infoData)->errorCode == 7){
            /*用刷新令牌之后来解决*/
            $newAccessToken = $this->_grantNewAccessToken($accessToken,$refreshToken);
            if($newAccessToken){
                $infoData = $this->searchUserInfo($accessToken,$refreshToken,$userId);
                return $infoData;
            }else{
                return -1;
            }
        }else{
            $infoData = $this->json_to_array(json_decode($infoData));
            return $infoData['data'];
        }
    }
    
    /**
     * 添加问题
     * @param array $data
     */
    public function addQuestion($data){
        
         
        $url = HTTP_DODOEDU.'/DDApi/question/addquestion';
      
        //更新token
        $this->_grantNewAccessToken($_SESSION['tokens']['accessToken'], $_SESSION['tokens']['refreshToken']);
        $data['access_token'] = $_SESSION['tokens']['accessToken'];
         
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
       
        return $query['data'];
    }
    /**
     * 获取学校信息
     * @param string $uid 必要参数是uid
     * @return Ambigous <string, mixed, multitype:unknown mixed string number >
     */
    public function getSchoolInfo($uid){
        
        $url = HTTP_DODOEDU.'/DDApi/school/schoolinfo';
        $data['user_id'] = $uid;
        //更新token
        $this->_grantNewAccessToken($_SESSION['tokens']['accessToken'], $_SESSION['tokens']['refreshToken']);
        $data['access_token'] = $_SESSION['tokens']['accessToken'];
       
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
        return $query['data'];
    }
    /**
     * 获取小站信息,公共接口，不需要token
     * @param     $elementId 组件ID
     * @param     $elementType 组件类型： Blog | Album|..
     * @param int $limit 获取的条数
     * @return Ambigous <string, mixed, multitype:unknown mixed string number >
     */
    public function getSiteInfo($elementId='72662181',$type='Forum',$limit=10){
        
        $url = HTTP_DODOEDU.'/DDApi/site/getsiteelementdata';
        $data['element_id'] = $elementId;
        $data['element_type'] = $type;
        $data['limit'] = $limit;
        //更新token
        //$this->_grantNewAccessToken($_SESSION['tokens']['accessToken'], $_SESSION['tokens']['refreshToken']);
        //$data['access_token'] = $_SESSION['tokens']['accessToken'];
         
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
        //var_dump(json_decode($query,1));
        return $query['data'];
    }
    /**
     * 添加标签
     * @param array $data
     * target_id,target,tags_array,creater_id
     * @return mixed
     */
    function add_tag($data){
        
         
        $url = HTTP_DODOEDU.'/DDApi/tag/updatetagrelation';
        
        //更新token
        $this->_grantNewAccessToken($_SESSION['tokens']['accessToken'], $_SESSION['tokens']['refreshToken']);
        $data['access_token'] = $_SESSION['tokens']['accessToken'];
         
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
        return $query['data'];
        
    }
    /**
     * 刷新token
     */
    public function updateToken(){
        $this->_grantNewAccessToken($_SESSION['tokens']['accessToken'], $_SESSION['tokens']['refreshToken']);
    }
    /**
     * 删除标签
     * @param array $data
     * 
     * @return mixed
     */
    function del_tag($data){
        
        $url = HTTP_DODOEDU.'/DDApi/tag/deltagrelation';
        //更新token
        $this->updateToken();
        $data['access_token'] = $_SESSION['tokens']['accessToken'];
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
        return $query['data'];
    }
    /**
     * 发送新鲜事
     * @param str $msg
     * 
     * @return mixed
     */
    function msg($msg){
        
        $url = HTTP_DODOEDU.'/DDApi/message/pushfangle';
        //更新token
        $this->updateToken();
        $data['access_token'] = $_SESSION['tokens']['accessToken'];
		$data['message'] = $msg;
        $query = json_decode(Cola_Com_Http::post($url, $data),1);
        return $query['data'];
    }

}


/**
 * @ignore
 */
class OAuthException extends Exception {
    // pass
}


