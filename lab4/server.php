<?php

define("sqlHost", "localhost");
define("sqlUser", "root");
define("sqlPass", "vertrigo");
define("sqlDbName", "Task4");

function connect_db() {
	$sqlID = mysql_pconnect(sqlHost, sqlUser, sqlPass) or die('error 1: '.mysql_error());
	mysql_select_db(sqlDbName, $sqlID) or die('error 2: '.mysql_error());
}


if (isset($_POST["id"])) {
	connect_db();
	
	$result = mysql_query("SELECT * FROM `hostel` WHERE `Id`=".intval($_POST["id"])) or die('error 2: '.mysql_error());
	$cnt = mysql_num_rows($result);
	if ($result && $cnt) {
		$row = mysql_fetch_assoc($result);
		die(json_encode(array(true, $row["Room"])));
	}
}
echo json_encode(array(false));
?>