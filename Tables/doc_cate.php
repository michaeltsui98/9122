<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_cate  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_cate' );
			self::$pk = 'cate_id';
		}
		public function getCate_id(){
			return self::$_data ['cate_id'];
		}
		public function getCate_name(){
			return self::$_data ['cate_name'];
		}
		public function getCate_pid(){
			return self::$_data ['cate_pid'];
		}
		public function getCate_sort(){
			return self::$_data ['cate_sort'];
		}
		public function setCate_id($value){
			return self::$_data ['cate_id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setCate_name($value){
			return self::$_data ['cate_name'] = $value;
			$this;
		}
		public function setCate_pid($value){
			return self::$_data ['cate_pid'] = $value;
			$this;
		}
		public function setCate_sort($value){
			return self::$_data ['cate_sort'] = $value;
			$this;
		}
}