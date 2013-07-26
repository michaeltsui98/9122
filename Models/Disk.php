<?php
class Models_Disk extends  Cola_Model{
    
    public function getDiskCount(){
        return Tables_Model::factory('ndisk')->count();
    }
    function get_log(){
        return  Orm_DB::select()->from('sys_log')->execute();
    }
    
}