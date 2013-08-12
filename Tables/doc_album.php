<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc_album  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc_album' );
			self::$pk = 'album_id';
		}
		public function getAlbum_id(){
			return self::$_data ['album_id'];
		}
		public function getUid(){
			return self::$_data ['uid'];
		}
		public function getTitle(){
			return self::$_data ['title'];
		}
		public function getDesc(){
			return self::$_data ['desc'];
		}
		public function getDoc_name(){
			return self::$_data ['doc_name'];
		}
		public function getFavs(){
			return self::$_data ['favs'];
		}
		public function getFile_num(){
			return self::$_data ['file_num'];
		}
		public function getViews(){
			return self::$_data ['views'];
		}
		public function setAlbum_id($value){
			return self::$_data ['album_id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setUid($value){
			return self::$_data ['uid'] = $value;
			$this;
		}
		public function setTitle($value){
			return self::$_data ['title'] = $value;
			$this;
		}
		public function setDesc($value){
			return self::$_data ['desc'] = $value;
			$this;
		}
		public function setDoc_name($value){
			return self::$_data ['doc_name'] = $value;
			$this;
		}
		public function setFavs($value){
			return self::$_data ['favs'] = $value;
			$this;
		}
		public function setFile_num($value){
			return self::$_data ['file_num'] = $value;
			$this;
		}
		public function setViews($value){
			return self::$_data ['views'] = $value;
			$this;
		}
}