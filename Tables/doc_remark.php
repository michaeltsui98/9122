<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_remark  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_remark' );
			self::$pk = 'id';
		}
		public function getId(){
			return self::$_data ['id'];
		}
		public function getUid(){
			return self::$_data ['uid'];
		}
		public function getObj_type(){
			return self::$_data ['obj_type'];
		}
		public function getObj_id(){
			return self::$_data ['obj_id'];
		}
		public function getTotal_mark(){
			return self::$_data ['total_mark'];
		}
		public function getFf(){
			return self::$_data ['ff'];
		}
		public function getTy(){
			return self::$_data ['ty'];
		}
		public function getMark_num(){
			return self::$_data ['mark_num'];
		}
		public function setId($value){
			return self::$_data ['id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setUid($value){
			return self::$_data ['uid'] = $value;
			$this;
		}
		public function setObj_type($value){
			return self::$_data ['obj_type'] = $value;
			$this;
		}
		public function setObj_id($value){
			return self::$_data ['obj_id'] = $value;
			$this;
		}
		public function setTotal_mark($value){
			return self::$_data ['total_mark'] = $value;
			$this;
		}
		public function setFf($value){
			return self::$_data ['ff'] = $value;
			$this;
		}
		public function setTy($value){
			return self::$_data ['ty'] = $value;
			$this;
		}
		public function setMark_num($value){
			return self::$_data ['mark_num'] = $value;
			$this;
		}
}