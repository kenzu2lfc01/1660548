<?php
include 'connect.php';
include 'functions.php';
if(isset($_POST['reset-password']))
{
  $email = $_POST['reset-email'];
  $password = $_POST['password']; 
  $confirmPassword = $_POST['confirm-password'];
  $verifyCode = $_POST['verify-code'];
  if($password == '' || $confirmPassword == '' || $verifyCode == '' || $email == '')
  {
   header('location:resetpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Please enter completely !</div>');	
   exit;
 }
 if($password != $confirmPassword)
 {
  header('location:resetpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Confirmed password is not correct !</div>');
  exit;
  }
  $check = checkUserVerifyCode($email,$verifyCode);
  if($check != 1)
  {
    header('location:resetpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Verify code is not correct !</div>');
    exit;
  }
  $passwordHash = password_hash($password,PASSWORD_DEFAULT);
  $query = $db->prepare("UPDATE users SET password=? WHERE email=?");
  $query->execute([$passwordHash, $email]);
  confirmUserVerifyCode($email,$verifyCode);
  header('location:resetpage.php?message=<div class="alert alert-success"><img src="icon/accept.ico" style="width:24px; height:24px; border:0"/> Reset password successfully !</div>');
}
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Reset password</title>
	<style>
		h6:hover
		 {
			 font-weight: bold;
		 }
	</style>
</head>
<body style="background:white">
  <?php include 'welcome-header.php'; ?>
  <div class="container" style="margin-left:none">
    <center><form method="POST" style="width:70%">
      <h2 style="color:#084B8A;text-shadow: 3px 3px #F2F2F2F2;margin-top:30px; float:left; font-weight: bold">Reset Password</h2><br/><br/><br/>
      <?php
      if(isset($_GET['message']))
      {
        $message = $_GET['message'];
        unset($_GET['message']);
        echo $message;
      }
      ?>
      <div class="form-group">
        <input type="email" name="reset-email" class="form-control" placeholder="Enter email">
      </div>
      <div class="form-group">
        <input type="password" name="password" class="form-control" placeholder="Enter new password">
      </div>
      <div class="form-group">
        <input type="password" name="confirm-password" class="form-control" placeholder="Confirm new password">
      </div>
      <div class="form-group">
        <input type="text" name="verify-code" class="form-control" placeholder="Enter verify code">
      </div>
      <div style="float:left">
        <h6><a href="index.php" style="color: #084B8A; float:left; text-shadow: 2px 2px #F2F2F2F2; text-decoration:none">Back to Sign In</a></h6>
      </div>
      <div style="float:right">
        <button type="submit" name="reset-password" class="btn btn-primary">Reset password</button>
      </div>
    </form></center>
  </div>
</body>
</html