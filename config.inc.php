<?php
$config = array(
    'site_name'=>'多多文库',
    '_urls' => array(
        '/^view\/?(\d+)?$/' => array(
            'controller' => 'IndexController',
            'action' => 'viewAction',
        ),
    ),
    '_routecache' => array(
            'adapter' => 'File'
    ),
    '_cache' => array(
            'adapter' => 'Memcache',
            'servers' => array(
                    'default' => array(
                            'host' => '172.16.0.3',
                            'port' => 8888,
                            'persistent' => true
                    )
            )
    ),
    '_db' => array(
        'adapter' => 'Mysqli',
        
            'host' => '127.0.0.1',
            'port' => 3306,
            'user' => 'root',
            'password' => '123456',
            'database' => 'df',
            'charset' => 'utf8',
            'persitent' => false
        
    ),
    '_xhprof' => array(
            'logDir' => 'D:\KKserv\wwwroot\xhprof\xhprof_log',
            'namespace' => '9122',
            'viewUrl' => 'http://localhost/xhprof/xhprof_html/index.php',
    ),

    '_modelsHome'      => 'Models',
    '_controllersHome' => 'Controllers',
    '_viewsHome'       => 'views',
    '_widgetsHome'     => 'widgets'
);
//模板缓存
define('TPL_CACHE', 1);
