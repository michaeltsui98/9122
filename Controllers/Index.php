<?php

/**
 * 首页
 * @author michael
 *
 */
class Controllers_Index extends Cola_Controller
{

    /**
     *
     * @var Models_Index
     */
    protected static $_model = NULL;

    function __construct ()
    {
        self::$_model = new Models_Index();
    }

    /**
     * 首页
     */
    function indexAction ()
    {
        
        
        $data = self::$_model->get_recommend_doc();
         $d1 = self::$_model->get_top_doc();
         var_dump($d1);
        
    }

    /**
     * 登录
     */
    function loginAction ()
    {
        $url = self::$_model->getOauthUrl();
        $this->redirect($url);
    }

    /**
     * 退出
     */
    function outAction ()
    {
        //$dis = Cola::getInstance()->getDispatchInfo();
        
        $i =  strpos($_SERVER['HTTP_REFERER'],'User');
        foreach( $_SESSION as $k => $v )
        {
            unset( $_SESSION[$k] );
        }
        if($i===false){
            $this->redirect($_SERVER['HTTP_REFERER']);
        }else{
            $this->redirect('/');
        }
    }
}

