<?php

class Controllers_Test extends Cola_Controller
{

    /**
     *
     * @var Models_Index
     */
    protected static $_model = NULL;

    function __construct ()
    {
        // self::$_model = new Models_Index();
    }

    /**
     * 数据分布
     */
    function pagerAction ()
    {
        $this->view->top_title = '分页测试';
        $test = new Models_Test();
        $page = $this->getVar('page');
        $res = $test->pagetest($page);
        $this->view->data = $res;
        $this->display('Index/test','master/test');
    }

    function indexAction ()
    {
        Cola_Request::isAjax();
        $this->display('Index/index');
    }

    function setCacheAction ()
    {
        $res = Cola::cache('test', 'i love you ', 6000);
    }

    function getCacheAction ()
    {
        phpinfo();
    }

    function testOrmAction ()
    {
        $model = new Models_Index();
        $res = $model->orm();
        var_dump($res);
    }

    function delAction ()
    {
        $res = self::$_model->ormDel();
        var_dump($res);
    }

    function updateAction ()
    {
        $res = self::$_model->ormUpdate();
        var_dump($res);
    }

    function insertAction ()
    {
        $res = self::$_model->ormInsert();
        var_dump($res);
    }

    function tableAction ()
    {
        $res = self::$_model->tableQuery();
        var_dump($res);
    }

    function modelAction ()
    {
        $res = self::$_model->modelCount();
        var_dump($res);
    }

    function modelInsertAction ()
    {
        $res = self::$_model->modelInsert();
        var_dump($res);
    }

    function modelUpdateAction ()
    {
        $res = self::$_model->modelUpdate();
        var_dump($res);
    }

    function modelDelAction ()
    {
        $res = self::$_model->modelDel();
        var_dump($res);
    }
}

?>