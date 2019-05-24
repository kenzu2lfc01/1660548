<?php
session_start();
if (!isset($_SESSION['email'])) {
  header('Location: index.php');
}
?>
<?php
if(isset($_POST['submit']))
{
  $old = $_POST['old-password'];
  $new = $_POST['new-password'];
  $confirm = $_POST['confirm-password'];
  if($old == '' || $new == '' || $confirm == '')
  {
    header('location:change-password.php?message=<div class="alert alert-danger">Please enter completely !</div>');
    exit;
  }
  error_reporting(E_ALL);
  ini_set('display_errors', 1);
  include 'connect.php';
  if($old != $_SESSION['password'])
  {
    header('location:change-password.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="height:24px; width:24px; border: 0"/> Password is not correct !</div>');
    exit;
  }
  if($new != $confirm)
  {
    header('location:change-password.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="height:24px; width:24px; border: 0"/> Confirmed password is not correct !</div>');
    exit;
  }              
  $passwordHash = password_hash($new,PASSWORD_DEFAULT);
  $query = $db->prepare("UPDATE users SET password=? WHERE email=?");
  $query->execute([$passwordHash, $_SESSION['email']]);
  header('location:change-password.php?message=<div class="alert alert-success"><img src="icon/accept.ico" style="height:24px; width:24px; border: 0"/> Change password successfully !</div>');
}
?>
<!DOCTYPE>
<html>
<head>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Change password</title>
  
</head>
<body style="background:#E6E6E6">
  <?php include 'welcome-header.php'; ?>
  <div class="container-fluid" style="background-color: white; width: 98%; height: 100%; margin-top: -10px">
    <center><form method="POST" style="width: 70%">
      <h4 style="color:#084B8A;text-shadow: 2px 2px #E6E6E6; margin-top: 30px; float: left;">Change Password</h4>
      <?php 
      if(isset($_GET['message']))
      {
        $message = $_GET['message'];
        unset($_GET['message']);
        echo '<br /><br /><br />'.$message;
      }
      ?>
      <div class="form-group">
        <input type="password" name="old-password" class="form-control" placeholder="Enter password">
      </div>
      <div class="form-group">
        <input type="password" name="new-password" class="form-control" placeholder="Enter new password">
      </div>
      <div class="form-group">
        <input type="password" name="confirm-password" class="form-control" placeholder="Confirm new password">
      </div>
      <button type="submit" name='submit' class="btn btn-success" style="width:100%; float:right">Change password</button>
    </form></center>
  </div>
</body>
</html>