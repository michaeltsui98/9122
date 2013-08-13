<?php
/**
 * oauth 登录，获取登录用户的信息保存在session['user'] 中
 */
error_reporting ( E_ALL | E_STRICT );
ini_set ( 'display_errors', 'on' );
date_default_timezone_set ( 'Asia/Shanghai' );
mb_internal_encoding ( 'utf-8' );
define ( 'DEBUG', TRUE );
header ( "Content-Type:text/html;charset=utf-8" );
define('S_ROOT', __DIR__.DIRECTORY_SEPARATOR);
define('BASE_PATH', '/9122');
require 'Cola/Cola.php';
$cola = Cola::getInstance ();

 
session_start();
ob_start();

/* define( 'DS' , DIRECTORY_SEPARATOR );
define( 'AROOT' , dirname( __FILE__ ) . DS  );
define( 'ROOT' , dirname( __FILE__ ) . DS .'_sy'.DS);
define( 'CROOT' , ROOT . 'core' . DS  );

include 'lib/DDClient.php'; */

$DDClient = new Models_DDClient();
/* include 'lib/app.function.php';
include '_sy/core/lib/core.function.php'; */

// var_dump($_SESSION);die;
if (isset($_GET['code'])) {
    
    $keys = array();
    $keys['code'] = $_REQUEST['code'];
    $keys['redirectUri'] = DD_CALLBACK_URL;
    
    if (!isset($_SESSION['tokens'])  OR $_REQUEST['remote_login'] == 1) {
        try {
            $tokens = $DDClient->getAccessToken('code', $keys);
            $_SESSION['tokens'] = $tokens;
        } catch (OAuthException $e) {
            echo $e;
        }
    } else {
        $tokens = $_SESSION['tokens'];
    }
    
    if (! empty($tokens)) {
        $userInfoArr = $DDClient->getUserCompleteInfoCurl($tokens['accessToken'], $tokens['refreshToken']);
        //$schoolInfo = $DDClient->searchUserInfo($userInfoArr['user_id']);
        //$userInfoArr += $schoolInfo;
        $_SESSION['user']  = $userInfoArr;
        $_SESSION['user']['uid']  = $userInfoArr['user_id'];
        $_SESSION['refUrl'] or $_SESSION['refUrl'] = BASE_PATH;
        Cola_Response::redirect($_SESSION['refUrl']);
    }
} else {
        Cola_Response::alert('非法请求',BASE_PATH);
}