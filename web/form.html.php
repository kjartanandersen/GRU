	<div class="kekkin">
	<nav class="navbar navbar-default" role="navigation">
  <!-- Brand and toggle get grouped for better mobile display -->

  <div class="navbar-header">
    
    
  </div>
</nav>
</div>
	<div class="container-fluid">
	<div class="container">
	<form role="form" action=" " method="post" id="validationform">
		<div class="containerskra">
			<div class="innskranau">
			<h2 class="innstxt" >Innskrá</h2>
			<p class="innstxt">Nauðsynlegt að fylla út í allt</p>
			<style type="text/css"> .neccecc{color: #A9A9A9;} </style>
			</div>
			<div class="skrainput">

			
			<div class="input-group">
				
  				<span class="input-group-addon" id="basic-addon1">Username</span>
  				<input name="username" type="username" class="form-control" id="fixinput" placeholder="Username" aria-describedby="basic-addon1" required />
			</div>
			<div class="input-group">
				<span class="input-group-addon" id="basic-addon1">Password</span>
				<input name="password" type="password" class="form-control" placeholder="Password" aria-describedy="basic-addon1" required />

			</div>

			

			</div>
		</div>
		<div class="skrainninput">
		<input type="submit" value="Innskrá" class="btn btn-default">
		<a class="btn btn-default" href="includes/index.php" role="button">Nýskrá</a>
		</div>
		<span><?php if (isset($error)) {
			echo $error; 
		} ?></span>
	</form>

	
	</div>


	</div>
