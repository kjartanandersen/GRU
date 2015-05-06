<?php
include "dbcon.php";
try {
	$sql = "SELECT username,nafn,password from notendur";
	$result = $pdo -> query($sql);

} catch (PDOException $ex) {
	echo 'Error: '.$e->getMessage();
}
while ($row = $result->fetch()) {
	$medlimur[] = array('username' => $row['username'],
						'nafn' => $row['nafn'],
						'password' => $row['password']
						);
}



?>
