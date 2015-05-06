<!DOCTYPE HTML>
<html>
<head>
	<title>GRU Forsíða</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="css/custon.css" rel="stylesheet" type="text/css">
    <script src="js/respond.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    
</head>
<body>
<?php
		

		include 'form.html.php';
		include 'vidburdir.php';
		include 'includes/login.php';

		if (isset($_SESSION['login_user'])) {
			header("location: includes/profile.php");
		}
	


?>
</body>
