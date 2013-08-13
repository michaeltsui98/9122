<?php

/**
 * 文库首页model
 * @author michael
 * @version 1.0 2013/8/12 14:17:34 
 */
class Models_Index extends Cola_Model
{

    /**
     * 获取推荐的文档，取最新的前10个
     */
    function get_recommend_doc ()
    {
        $sql = "select doc_id, doc_title,doc_page_key from doc 
                where recommend =1 
                order by doc_id desc
                limit 0,10  ";
        $key = $this->cache_key('get_recommend');
        $data = $this->cache()->get($key);
        if (! $data) {
            $data = $this->sql($sql);
            $this->cache()->set($key, $data, 1800);
        }
        return $data;
    }

    /**
     * 获取本周，本月，本年， 的文档排行榜
     * 按下载次数+阅读次数
     *
     * @param string $unit
     *            (week,month,year)
     * @return array;
     */
    function get_top_doc ($unit = 'week')
    {
        $sql = "select doc_id,doc_title from doc
            where DATE_SUB(CURDATE(),INTERVAL 1 $unit) <= DATE(FROM_UNIXTIME(on_time))
            order by doc_views+doc_downs desc limit 0,10";
        $key = $this->cache_key('get_top_doc', func_get_args());
        $data = $this->cache()->get($key);
        if (! $data) {
            $data = $this->sql($sql);
            $this->cache()->set($key, $data, 1800);
        }
        return $data;
    }

    /**
     * 生成oauth登录的url
     *
     * @return string
     */
    function getOauthUrl ()
    {
        $refUrl = $_SERVER['HTTP_REFERER'];
        $_SESSION['refUrl'] = $refUrl;
        $_SESSION['state'] = md5(uniqid(rand(), TRUE));
        $DDClient = new Models_DDClient();
        return $DDClient->getAuthorizeURL(DD_CALLBACK_URL, 'code', 
                $_SESSION['state']);
    }
}
 