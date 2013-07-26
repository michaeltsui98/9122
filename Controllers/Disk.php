<?php

/**
 * @var 后台网盘
 * @author michael
 *
 */
class Controllers_Disk extends Cola_Controller
{

    /**
     * 查看网盘
     */
    function indexAction ()
    {
        $this->view->row = Models_Disk::init()->getDiskCount();
        $this->view->a ='test'; 
        
        //$data = $this->getComment();
        
        $test = "43434343";
         
//         $arr =  Orm_DB::select()->from('ndisk')->where('disk_id', '=', 2)->getCol()->execute();
       
       // $arr = Tables_Model::factory('ndisk')->query();
        
        //$tn = new Tables_ndisk;
        
        
        //var_dump($arr);
      
        $this->display('index');
    }
    function sysLog($cont){
        $data  = $this->getComment();
        
    }
    function widget(){
        $this->view->a = '这个王八蛋';
        $dm = new Models_Disk();
        $res = $dm->get_log();
        $this->view->res = $res;
        $this->display('index/wid');
    }
    
    
}
