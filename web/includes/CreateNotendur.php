<?php
if (get_magic_quotes_gpc()) 
{
	$process = array(&$_GET, &$_POST, &$_COOKIE, &$_REQUEST);
	while (list($key, $val) = each($process))
	{
		foreach ($val as $k => $v)
		{
			unset($process[$key][$k]);
			if (is_array($v))
			{
				$process[$key][stripslashes($k)] = $v;
				$process[] = &$process[$key][stripslashes($k)];
			}
			else
			{
				$process[$key][stripslashes($k)] = stripslashes($v);
			}
		}
	}
	unset($process);
	
}

try {
	$sql = 'INSERT INTO notendur SET
	username = :username,
	nafn = :fullname,
	password = :password,
	status = 00';
	$s = $pdo->prepare($sql);
	if (isset($_REQUEST['username']) and isset($_REQUEST['fullname']) and isset($_REQUEST['password'])) {
	$s->bindValue(':username',$_POST['username']);
	$s->bindValue(':fullname',$_POST['fullname']);
	$s->bindValue(':password',$_POST['password']);
	$s->Execute();

}
	if (isset($_POST['username']) and isset($_POST['fullname']) and isset($_POST['password']))    
{    
	include "takk.php";
}
} catch (PDOException $e) 
{
	$error = 'Error: ' . $e->getMessage();
		include 'error.html.php';
		exit();
	
}


?>
