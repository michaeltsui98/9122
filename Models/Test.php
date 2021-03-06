<?php

class Models_Test extends Cola_Model
{

    
    
    
    function set_cache(){
        
    }
    function pagetest($page){
        $sql = "select * from sys_log";
        $limit = 2;
        $url = BASE_PATH . '/index.php/Test/pager/page/%page%';
        $res = Tables_Model::factory()->sql_pager($sql, $page, $limit, $url);
        return $res;
    }
    
    function test ()
    {
        $sql = "select `ad_id` from keke_witkey_ad where ad_id = 292";
        
        return $this->db()->col($sql);
    }
    function testCache(){
        return  $this->cached('test');
    }
    
    function testModel(){
        
       return  $this->count('ad_id = 292','keke_witkey_ad');
    }

    function orm ()
    {
        return Orm_DB::select('ad_id')
            ->from('keke_witkey_ad')
            ->where('ad_id', '=', 292)
            
            ->getCol()
            ->execute();
    }

    function ormDel ()
    {
        return Orm_DB::delete('keke_witkey_ad')->where('ad_id', '=', 236)->execute();
    }

    function ormUpdate ()
    {
        return Orm_DB::update('keke_witkey_ad')->set(array(
                'ad_type' => 'text'
        ))
            ->where('ad_id', '=', 292)
            ->execute();
    }

    function ormInsert ()
    {
        $data = array(
                'target_id' => 1,
                'ad_type' => 'flash'
        );
        return Orm_DB::insert('keke_witkey_ad')->columns(array_keys($data))
            ->values(array_values($data))
            ->execute();
    }

    function tableQuery ()
    {
        return Tables_Model::factory('keke_witkey_ad')->query();
       
    }

    function modelCount ()
    {
        return Tables_keke_witkey_ad::instance()->count();
    }

    function modelInsert ()
    {
        return Tables_keke_witkey_ad::instance()->setAd_name('test')
            ->setAd_type('text')
            ->setAd_content('content')
            ->insert();
    }

    function modelUpdate ()
    {
        return Tables_keke_witkey_ad::instance()->setAd_name('update297')
            ->setAd_content('update_content297')
            ->setAd_url('www.163.com')
            ->setWhere('ad_id=297')
            ->update();
    }

    function modelDel ()
    {
        return Tables_keke_witkey_ad::instance()->setAd_id('296')->del();
    }
}

?>