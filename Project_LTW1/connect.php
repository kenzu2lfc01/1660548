<?php 
$db = new PDO("mysql:host=localhost:3306;dbname=nguyenvu_tuevo_btcn06;charset=utf8",'tuevo','asdasd', array(PDO::MYSQL_ATTR_INIT_COMMAND =>  "SET NAMES utf8"));
         $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
?>