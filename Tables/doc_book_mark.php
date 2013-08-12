<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_book_mark  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_book_mark' );
			self::$pk = 'mark_id';
		}
		public function getMark_id(){
			return self::$_data ['mark_id'];
		}
		public function getDoc_id(){
			return self::$_data ['doc_id'];
		}
		public function getUid(){
			return self::$_data ['uid'];
		}
		public function getMark_num(){
			return self::$_data ['mark_num'];
		}
		public function setMark_id($value){
			return self::$_data ['mark_id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setDoc_id($value){
			return self::$_data ['doc_id'] = $value;
			$this;
		}
		public function setUid($value){
			return self::$_data ['uid'] = $value;
			$this;
		}
		public function setMark_num($value){
			return self::$_data ['mark_num'] = $value;
			$this;
		}
}