<?php
if(isset($_POST['submit']))
{
  $fullname = $_POST['fullname'];
  $phone = $_POST['phone'];
  $email = $_POST['email'];
  $password = $_POST['password']; 
  $confirm = $_POST['confirm'];
  $verifyCode = $_POST['verify'];
  error_reporting(E_ALL);
  ini_set('display_errors', 1);
  include 'connect.php';
  include 'functions.php';
  if($fullname == null || $phone == null || $password == null || $confirm == null || $verifyCode == '')
  {
    header('location:registerpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Please enter completely !</div>');
    exit;
  }
  if(checkIfEmailExisted($email) == 1)
  {
    header('Location:registerpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Your email is used !</div>');
    exit;
  }
  if($password != $confirm)
  {
    header('location:registerpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Confirmed password is not correct !</div>');
    exit;
  }
  $check = checkUserVerifyCode($email,$verifyCode);
  if($check != 1)
  {
    header('location:registerpage.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Verify code is not correct !</div>');
    exit;
  }
  $passwordHash = password_hash($password,PASSWORD_DEFAULT);
  $query = $db->prepare("INSERT INTO users(fullname,email,password,phone,avatar) VALUES(?,?,?,?,?)");
  $query->execute([$fullname,$email,$passwordHash,$phone,'default-avatar.png']);
  confirmUserVerifyCode($email,$verifyCode);
  header('location: registerpage.php?message=<div class="alert alert-success"><img src="icon/accept.ico" style="width:24px; height:24px; border:0"/> Account has been created successfully !</div>');
} 
?>
<!DOCTYPE>
<html>
<head>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">	
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Register</title>
</head>
<body style="background:white">
  <?php include 'welcome-header.php'; ?>
  <div class="container-fluid" style="margin-left:none">
    <center><form method="POST" style="width: 70%">
      <h2 style="color:#084B8A;text-shadow: 3px 3px #F2F2F2F2;margin-top:30px; float:left; font-weight: bold">Register Account</h2><br/><br/><br/>
      <?php
      if(isset($_GET['message']))
      {
        $message = $_GET['message'];
        unset($_GET['message']);
        echo $message;
      }
      ?>
      <div class="form-group">
        <input type="text" name="fullname" class="form-control" placeholder="Enter full name">
      </div>
      <div class="form-group">
        <input type="email" name="email" class="form-control" placeholder="Enter email">
      </div>
      <div class="form-group">
        <input type="text" name="phone" class="form-control" placeholder="Enter phone number">
      </div>
      <div class="form-group">
        <input type="password" name="password" class="form-control" placeholder="Enter password">
      </div>
      <div class="form-group">
        <input type="password" name="confirm" class="form-control" placeholder="Confirm password">
      </div>
      <div class="form-group">
        <input type="text" name="verify" class="form-control" placeholder="Enter verify code">
      </div>
      <div style="float: right;">
        <button type="submit" name="submit" class="btn btn-primary" style="width: 100px">Register</button>
      </div>
      <div style="float:left">
        <h6><a href="index.php" style="color: #084B8A; text-shadow: 2px 2px #F2F2F2F2; text-decoration:none">Back to Sign In</a></h6>
      </div>
    </form></center>
  </div>
</body>
</html>