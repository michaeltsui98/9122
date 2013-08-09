<?php
/**
 * 网站挂件
 * @author michael
 * @date 2013-08-09
 */
class Controllers_Widget extends Cola_Controller
{
    protected static $_model = NULL;

    function __construct ()
    {}
    
    function header(){
        $this->view->a = 'test widget';
        $this->display('Index/wid');
    }
    
}
 