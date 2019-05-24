<?php
include 'connect.php';
include 'functions.php';
if (!isset($_SESSION['email']))
 header('Location: login.php');
 include 'functions.php';
$current_user = getCurrentUser();
if(isset($_GET['userid']))
  $user = getUserById($_GET['userid']);
if(isset($_POST['send']) && $_POST['message'] != '')
{
  error_reporting(E_ALL);
  ini_set('display_errors', 1);
  $message = $_POST['message'];
  $message = htmlentities($message);
  $query = $db->prepare("INSERT INTO messages(senderId, recieverId, message) VALUES(?,?,?)");
  $query->execute([$current_user['id'],$user['id'],$message]);
}
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="t.ico" />
  <title>Post</title>
  
</head>
<body>
  <div class="container" style="margin-left: -20px; width: 103%;">
    <form method="POST">
      <div class="form-group">
        <textarea name="message" style="width:100%;height:130px;" placeholder="Send a message to<?php echo getName($user['fullname']); ?>"></textarea>
      </div>
      <button type="submit" name="send" style="float:right; margin-bottom: 20px; margin-top: -10px; width: 100px;" class="btn btn-primary">Send</button>
    </form>
  </div>
</body>
</html>
