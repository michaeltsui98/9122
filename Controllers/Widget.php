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
    
    /**
     * 头部 调用方式 {widget('Widget','header')}	
     */
    function header(){
        $this->view->a = 'test widget';
        $this->display('widget/header');
    }
    /**
     * 多级知识节点调用
     */
    function node(){
        
    }
    /**
     * 多级分类调用
     */
    function cate(){
        
    }
    
}
 