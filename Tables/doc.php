<?php 
 /** 
 * @Copyright Michael 
 * @author Michaeltsui98 
 * @version 3.0 2013/8/12 14:17:34 
 */
class Tables_doc  extends Tables_Model {
		function  __construct(){
			parent::__construct ( 'doc' );
			self::$pk = 'doc_id';
		}
		public function getDoc_id(){
			return self::$_data ['doc_id'];
		}
		public function getUip(){
			return self::$_data ['uip'];
		}
		public function getUid(){
			return self::$_data ['uid'];
		}
		public function getUser_name(){
			return self::$_data ['user_name'];
		}
		public function getDoc_title(){
			return self::$_data ['doc_title'];
		}
		public function getDoc_summery(){
			return self::$_data ['doc_summery'];
		}
		public function getCate_id(){
			return self::$_data ['cate_id'];
		}
		public function getXd(){
			return self::$_data ['xd'];
		}
		public function getXk(){
			return self::$_data ['xk'];
		}
		public function getNj(){
			return self::$_data ['nj'];
		}
		public function getBb(){
			return self::$_data ['bb'];
		}
		public function getZt(){
			return self::$_data ['zt'];
		}
		public function getDoc_pages(){
			return self::$_data ['doc_pages'];
		}
		public function getDoc_views(){
			return self::$_data ['doc_views'];
		}
		public function getDoc_favs(){
			return self::$_data ['doc_favs'];
		}
		public function getDoc_remarks(){
			return self::$_data ['doc_remarks'];
		}
		public function getDoc_downs(){
			return self::$_data ['doc_downs'];
		}
		public function getDoc_credit(){
			return self::$_data ['doc_credit'];
		}
		public function getDoc_price(){
			return self::$_data ['doc_price'];
		}
		public function getDoc_page_key(){
			return self::$_data ['doc_page_key'];
		}
		public function getDoc_swf_key(){
			return self::$_data ['doc_swf_key'];
		}
		public function getDoc_pdf_key(){
			return self::$_data ['doc_pdf_key'];
		}
		public function getDoc_file_name(){
			return self::$_data ['doc_file_name'];
		}
		public function getDoc_ext_name(){
			return self::$_data ['doc_ext_name'];
		}
		public function getDoc_status(){
			return self::$_data ['doc_status'];
		}
		public function getDoc_source(){
			return self::$_data ['doc_source'];
		}
		public function getIs_ok(){
			return self::$_data ['is_ok'];
		}
		public function getDisk_id(){
			return self::$_data ['disk_id'];
		}
		public function getFile_id(){
			return self::$_data ['file_id'];
		}
		public function getFile_md5(){
			return self::$_data ['file_md5'];
		}
		public function getIs_dir(){
			return self::$_data ['is_dir'];
		}
		public function getDir_id(){
			return self::$_data ['dir_id'];
		}
		public function getIs_sale(){
			return self::$_data ['is_sale'];
		}
		public function getIs_lock(){
			return self::$_data ['is_lock'];
		}
		public function getOn_time(){
			return self::$_data ['on_time'];
		}
		public function setDoc_id($value){
			return self::$_data ['doc_id'] = $value;
			self::$pk_val = $value;
			$this;
		}
		public function setUip($value){
			return self::$_data ['uip'] = $value;
			$this;
		}
		public function setUid($value){
			return self::$_data ['uid'] = $value;
			$this;
		}
		public function setUser_name($value){
			return self::$_data ['user_name'] = $value;
			$this;
		}
		public function setDoc_title($value){
			return self::$_data ['doc_title'] = $value;
			$this;
		}
		public function setDoc_summery($value){
			return self::$_data ['doc_summery'] = $value;
			$this;
		}
		public function setCate_id($value){
			return self::$_data ['cate_id'] = $value;
			$this;
		}
		public function setXd($value){
			return self::$_data ['xd'] = $value;
			$this;
		}
		public function setXk($value){
			return self::$_data ['xk'] = $value;
			$this;
		}
		public function setNj($value){
			return self::$_data ['nj'] = $value;
			$this;
		}
		public function setBb($value){
			return self::$_data ['bb'] = $value;
			$this;
		}
		public function setZt($value){
			return self::$_data ['zt'] = $value;
			$this;
		}
		public function setDoc_pages($value){
			return self::$_data ['doc_pages'] = $value;
			$this;
		}
		public function setDoc_views($value){
			return self::$_data ['doc_views'] = $value;
			$this;
		}
		public function setDoc_favs($value){
			return self::$_data ['doc_favs'] = $value;
			$this;
		}
		public function setDoc_remarks($value){
			return self::$_data ['doc_remarks'] = $value;
			$this;
		}
		public function setDoc_downs($value){
			return self::$_data ['doc_downs'] = $value;
			$this;
		}
		public function setDoc_credit($value){
			return self::$_data ['doc_credit'] = $value;
			$this;
		}
		public function setDoc_price($value){
			return self::$_data ['doc_price'] = $value;
			$this;
		}
		public function setDoc_page_key($value){
			return self::$_data ['doc_page_key'] = $value;
			$this;
		}
		public function setDoc_swf_key($value){
			return self::$_data ['doc_swf_key'] = $value;
			$this;
		}
		public function setDoc_pdf_key($value){
			return self::$_data ['doc_pdf_key'] = $value;
			$this;
		}
		public function setDoc_file_name($value){
			return self::$_data ['doc_file_name'] = $value;
			$this;
		}
		public function setDoc_ext_name($value){
			return self::$_data ['doc_ext_name'] = $value;
			$this;
		}
		public function setDoc_status($value){
			return self::$_data ['doc_status'] = $value;
			$this;
		}
		public function setDoc_source($value){
			return self::$_data ['doc_source'] = $value;
			$this;
		}
		public function setIs_ok($value){
			return self::$_data ['is_ok'] = $value;
			$this;
		}
		public function setDisk_id($value){
			return self::$_data ['disk_id'] = $value;
			$this;
		}
		public function setFile_id($value){
			return self::$_data ['file_id'] = $value;
			$this;
		}
		public function setFile_md5($value){
			return self::$_data ['file_md5'] = $value;
			$this;
		}
		public function setIs_dir($value){
			return self::$_data ['is_dir'] = $value;
			$this;
		}
		public function setDir_id($value){
			return self::$_data ['dir_id'] = $value;
			$this;
		}
		public function setIs_sale($value){
			return self::$_data ['is_sale'] = $value;
			$this;
		}
		public function setIs_lock($value){
			return self::$_data ['is_lock'] = $value;
			$this;
		}
		public function setOn_time($value){
			return self::$_data ['on_time'] = $value;
			$this;
		}
}