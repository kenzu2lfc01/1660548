<?php
session_start();
include 'connect.php';
include 'functions.php';
if(isset($_POST['submit']))
{
  $email = $_POST['email'];
  $password = $_POST['password'];
  error_reporting(E_ALL);
  ini_set('display_errors', 1);
  $stmt = $db->prepare("SELECT * FROM users WHERE email=?");
  $stmt->execute(array($email));
  $user = $stmt->fetch(PDO::FETCH_ASSOC);
  if(!$user)
  {
    header('location:index.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Email or password is not correct !</div>');
  }
  else
  {
    $result = password_verify($password,$user['password']);
    if($result)
    {
      $_SESSION['email'] = $email;
      $_SESSION['password'] = $password;
      header('Location: index.php');
    }
    else
    {
      header('location:index.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Email or password is not correct !</div>');
    } 
  }
}
if(isset($_POST['emotion-post']))
  header('location: index.php');
if(isset($_POST['share']))
  header('location: index.php');
if(isset($_POST['post-comment-button']))
  header('location: index.php');
?>
<!DOCTYPE>
<html>
<head>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Tuebook</title>
  <style>
  .card{
    margin-top:30px
  }
  li:hover { 
    background-color: blue;
  }
  tr {
    background-size: cover;
  }
  body
  {
   z-index: 2;
   background-color: rgba(4, 95, 180, 0.3);
 }
 .containter
 {
   z-index: 1;
 }
 h6:hover
 {
  font-weight: bold;
}
</style>

<script type="text/javascript">
  //Referrence source: https://stackoverflow.com/questions/6320113/how-to-prevent-form-resubmission-when-page-is-refreshed-f5-ctrlr -->
  //Prevent form from resubmission
  if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
  }
  //Keep the scrolling position after reload page
  //Referrence source: https://github.com/evaldsurtans/maintainscroll.jquery.js/blob/master/maintainscroll.js
  document.addEventListener('DOMContentLoaded', function() {
  var sep = '\uE000'; // an unusual char: unicode 'Private Use, First'

  window.addEventListener('pagehide', function(e) {
    window.name += sep + window.pageXOffset + sep + window.pageYOffset;
  });

  if(window.name && window.name.indexOf(sep) > -1)
  {
    var parts = window.name.split(sep);
    if(parts.length >= 3)
    {
      window.name = parts[0];
      window.scrollTo(parseFloat(parts[parts.length - 2]), parseFloat(parts[parts.length - 1]));
    }
  }
});
</script>
</head>
<body style="background:#e6e6e6e6" reload="window.location = window.location.href;">
  <?php include 'welcome-header.php'; ?>
  <div class="container<?php if(!isset($_SESSION['email'])) echo'-fluid';?>" style="<?php if(!isset($_SESSION['email'])) echo 'width:90%; height: 83%;background-color: white; box-shadow: 3px 3px gray';?>;">     
    <?php
    if(!isset($_SESSION['email']))
    {
      echo '<marquee direction="left"><h3 style="color:#084B8A;margin-top:10px;text-shadow: 3px 3px #F2F2F2F2; font-weight: bold">Welcome to Tuebook !</h3></marquee>';
      echo'
      <center><form method="POST" style="width: 70%;"">';
      echo '
      <h2 style="color:#084B8A;text-shadow: 3px 3px #F2F2F2F2;margin-top:30px; float:left; font-weight: bold">Sign In Account</h2><br/><br/><br/>';
      if(isset($_GET['message']))
      {
        $message = $_GET['message'];
        unset($_GET['message']);
        echo $message;
      }
      echo '
      <div class="form-group">
      <input type="email" name="email" class="form-control" aria-describedby="emailHelp" placeholder="Enter email">
      </div>
      <div class="form-group">
      <input type="password" name="password" class="form-control" placeholder="Enter password">
      </div>
      <div class="register">
      <h6><a href="register.php" style="color: #084B8A; float:left;text-shadow: 2px 2px #F2F2F2F2; text-decoration:none">Register</a></h6>
      </div>
      <button type="submit" name="submit" class="btn btn-success" style="width:100px; float:right; margin-top:5px; height:38px"><img src="icon/login.ico" style="width:24px; height:24px"/> Login</button>
      <div class="forgot-pasword">
      <br/><h6><a href="reset-password.php" style="color: #084B8A; float:left;text-shadow: 2px 2px #F2F2F2F2; text-decoration:none">Forgot password</a></h6>
      </div>
      </form></center>';
    }
    else
    {
      echo '<div style="width:100%; float:left; margin-top:20px">';
      include 'post.php';
      include 'display-posts.php';
      echo '</div>';
    }
    ?>
    <?php if(!isset($_SESSION['email'])): ?>
     <center>
       <div style="margin-top:80px">
        <h6 style="color: #084B8A; text-shadow: 2px 2px #F2F2F2F2">Copyright by ©Team06-ITUS</h6>
      </div>
    </center>
  <?php endif; ?>
</div>
</body>
</html>
