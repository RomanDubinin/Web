<?php # HelloClientWsdl.php

   $client = new SoapClient("Hello.wsdl");
	  
   $return1 = $client->hello('123 3');
   echo $return1; 
   
   echo nl2br("\n");
   
   $return2 = $client->hello("3 4");
   echo $return2;    
?>