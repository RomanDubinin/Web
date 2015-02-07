<?php # HelloServerWsdl.php

function hello($someone) {
	return strrev($someone);
}

   ini_set("soap.wsdl_cache_enabled", "0"); //отключил кеширование wsdl
   $server = new SoapServer("http://localhost/Hello.wsdl");
   $server->addFunction("hello"); 
   $server->handle(); 
?>