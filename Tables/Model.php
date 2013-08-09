<?php

/**
 * 模型操作的基类
 * 可以操作所有表映射类
 *
 * @author Michaeltsui98
 * @version 3.0
 */
class Tables_Model
{

    public static $db;

    public $tableName;

    public $replace = 0;

    public static $pk = NULL;

    public static $pkVal = NULL;

    public static $data = array();

    public static $where = NULL;

    protected static $_instance = null;
    
    // protected $_class;
    public function __construct ($tableName = null)
    {
        $model = new Cola_Model();
        self::$db = $model->db();
        $this->tableName = $tableName;
        // $class = 'Tables_' . $tableName;
    }

    public static function loadClass ($className)
    {
        if (class_exists($className, false) ||
                 interface_exists($className, false)) {
            return true;
        }
        if (strpos($className, 'Tables') !== FALSE) {
            $class = substr($className, 7);
            $classFile = 'Tables' . DIRECTORY_SEPARATOR . $class . '.php';
            include ($classFile);
            return TRUE;
        }
    }

    /**
     *
     * @param string $table_name            
     * @return self
     */
    public static function factory ($tableName=null)
    {
        if($tableName===null){
            return new Tables_Model();
        }
        try {
            $class = 'Tables_' . $tableName;
            if (self::$_instance[$tableName] == null) {
                if (self::loadClass($class)) {
                    self::$_instance[$tableName] = new $class();
                }
            }
        } catch (Exception $e) {
            throw new Cola_Exception('can not load ' . $class);
        }
        
        return self::$_instance[$tableName];
    }

    /**
     * 设置条件
     *
     * @return self
     */
    public function setWhere ($value)
    {
        self::$where = $value;
        return $this;
    }

    /**
     * 字段设值,只对添加，更新有效
     *
     * @param $array 字段健值对数组            
     * @return Model
     */
    public function setData ($array)
    {
        self::$data = array_unique($array);
        return $this;
    }

    /**
     * 插入数据
     */
    function insert ()
    {
        $res = static::$db->insert(self::$data, $this->tableName);
        $this->reset();
        return $res;
    }

    /**
     * 更新数据
     */
    function update ()
    {
        if (! self::$where and isset(self::$pkVal)) {
            self::$where = self::$pk . '=' . self::$pkVal;
        }
        $res = static::$db->update(self::$data, self::$where, $this->tableName);
        $this->reset();
        return $res;
    }

    /**
     *
     * @param string $fields
     *            查询字段，默认值为*
     * @param int $cache_time
     *            null 表示默认缓存,0 表示不缓存，1，表示缓存1秒钟
     * @param
     *            array
     */
    function query ($fields = '*', $cache_time = 0)
    {
        empty($fields) and $fields = '*';
        if (self::$where) {
            $sql = "select $fields from $this->tableName where " . self::$where;
        } else {
            $sql = "select $fields from $this->tableName";
        }
        empty($fields) and $fields = '*';
        $this->reset();
        
        return self::$db->sql($sql);
    }

    /**
     * 删除记录
     */
    function del ()
    {
        if (! self::$where and self::$pkVal) {
            self::$where = self::$pk . '=' . self::$pkVal;
        }
        $sql = "delete from $this->tableName where " . self::$where;
        $this->reset();
        return self::$db->result($sql);
    }

    /**
     * 统计记录数
     */
    function count ()
    {
        if (self::$where) {
            $sql = "select count(*) as count from $this->tableName where " .
                     self::$where;
        } else {
            $sql = "select count(*) as count from $this->tableName";
        }
        $this->reset();
        // die($sql);
        return self::$db->col($sql);
    }

    /**
     * 返回一行数据
     * 
     * @return array
     */
    function row ()
    {
        if (self::$where) {
            $sql = "select * from $this->tableName where " . self::$where;
        } else {
            $sql = "select * from $this->tableName";
        }
        $this->reset();
        return (array) self::$db->row($sql);
    }

    /**
     * 单个字段的值
     * 
     * @param string $filed
     *            可以是字段名，也可以是表达式
     * @return Ambigous <string, NULL, mixed>
     */
    function col ($filed = NULL)
    {
        $filed or $filed = '*';
        if (self::$where) {
            $sql = "select $filed from $this->tableName where " . self::$where;
        } else {
            $sql = "select $filed from $this->tableName";
        }
        
        $this->reset();
        return self::$db->col($sql);
    }

    function reset ()
    {
        self::$where = NULL;
    }

    /**
     * 过滤掉NULL值
     *
     * @param Sting $v            
     * @return boolean
     */
    public static function remove_null ($v)
    {
        if (is_null($v)) {
            return FALSE;
        }
        return TRUE;
    }
    /**
     * 通过sql  获取数据与分页信息
     * @param string $sql 不要带limit子句，本方法会依据参数生成 
     * @param int $page  1
     * @param int $limit 20 
     * @param string $url  BASE_PATH."/index.php/Admin_Log/index/page/%page%/fid/$fid/cond/$cond/val/$val";
     * @return boolean|multitype:string Ambigous <mixed, resource>
     */
    public function sql_pager ($sql, $page, $limit, $url)
    {
        (int) $page or $page = 1;
        (int) $limit or $limit = 20;
        
        if ($page > 0) {
            $start = ($page - 1) * $limit;
            $limits = ' limit ' . $start . ',' . $limit;
        }
        $data = self::$db->sql($sql . $limits);
        $sql = "select count(*) from (" . $sql . ") as sy";
        $count = self::$db->col($sql);
        
        $pager = new Cola_Com_Pager($page, $limit, $count, $url);
        $html = $pager->html();
        if (! $data)
            return false;
        return array(
                'data' => $data,
                'page' => $html
        );
    }
}
    
 