<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_album_info  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_album_info' );
			self::$pk = 'id';
		}
		public function getId(){
			return self::$_data ['id'];
		}
		public function getAlbum_id(){
			return self::$_data ['album_id'];
		}
		public function getDoc_id(){
			return self::$_data ['doc_id'];
		}
		public function setId($value){
			return self::$_data ['id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setAlbum_id($value){
			return self::$_data ['album_id'] = $value;
			$this;
		}
		public function setDoc_id($value){
			return self::$_data ['doc_id'] = $value;
			$this;
		}
}