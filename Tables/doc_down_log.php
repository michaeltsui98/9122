<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_down_log  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_down_log' );
			self::$pk = 'id';
		}
		public function getId(){
			return self::$_data ['id'];
		}
		public function getUid(){
			return self::$_data ['uid'];
		}
		public function getDoc_id(){
			return self::$_data ['doc_id'];
		}
		public function getDown_num(){
			return self::$_data ['down_num'];
		}
		public function getCredit(){
			return self::$_data ['credit'];
		}
		public function getCost(){
			return self::$_data ['cost'];
		}
		public function getBuy_time(){
			return self::$_data ['buy_time'];
		}
		public function getOn_time(){
			return self::$_data ['on_time'];
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
		public function setDoc_id($value){
			return self::$_data ['doc_id'] = $value;
			$this;
		}
		public function setDown_num($value){
			return self::$_data ['down_num'] = $value;
			$this;
		}
		public function setCredit($value){
			return self::$_data ['credit'] = $value;
			$this;
		}
		public function setCost($value){
			return self::$_data ['cost'] = $value;
			$this;
		}
		public function setBuy_time($value){
			return self::$_data ['buy_time'] = $value;
			$this;
		}
		public function setOn_time($value){
			return self::$_data ['on_time'] = $value;
			$this;
		}
}