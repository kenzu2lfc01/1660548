<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;
if(isset($_POST['send-mail-to-reset']))
{
// Import PHPMailer classes into the global namespace
// These must be at the top of your script, not inside a function

//Load Composer's autoloader
require 'vendor/autoload.php';
include 'connect.php';
include 'functions.php';
$email = $_POST['email'];
if($email == '')
{
    header('Location:reset-password.php?message=<div class="alert alert-danger"><img src="icon/refuse.ico" style="width:24px; height:24px; border:0"/> Please enter your email !</div>');
  exit;
}
$stmt = $db->prepare("SELECT * FROM users WHERE email=?");
$stmt->execute(array($email));
$user = $stmt->fetch(PDO::FETCH_ASSOC);
$link = null;
if ($user)
{
  $verifyCode = generateString();
    $query = $db->prepare("INSERT INTO userverifycodes(email,verifycode,status) VALUES(?,?,?)");
    $query->execute([$email,$verifyCode,'available']);
    $link = 'tuevo.daonguyenvu.com/Web1-DACK-Nhom06/resetpage.php';
    
        $mail = new PHPMailer(true);                              // Passing `true` enables exceptions
        try {
            //Server settings
            $mail->SMTPDebug = 2;                                 // Enable verbose debug output
            $mail->isSMTP();                                      // Set mailer to use SMTP
            $mail->Host = 'smtp.gmail.com';  // Specify main and backup SMTP servers
            $mail->SMTPAuth = true;                               // Enable SMTP authentication
            $mail->Username = 'ltweb1.cd2018@gmail.com';                 // SMTP username
            $mail->Password = 'abc123XYZ~';                           // SMTP password
            $mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also accepted
            $mail->Port = 587;                                    // TCP port to connect to

            //Recipients
            $mail->setFrom('ltweb1.cd2018@gmail.com', 'Tuebook');
            $mail->addAddress($email, $email);     // Add a recipient

            //Content
            $mail->isHTML(true);                                  // Set email format to HTML
            $mail->Subject = 'Reset password instructions';
            $mail->Body    = 'Hello <strong>'. $email .'</strong>' . '
            <br/>Someone has requested a link to change your password. You can do this through the link below.' . '
            <br/><a href="'. $link .'" target="blank">Change my password</a>' . "
            <br/>Your verify code is <b>" .$verifyCode. "</b>
            <br/>If you didn't request this, please ignore this email." . "
            <br/>Your password won't change until you access the link above and create a new one.";

            $mail->send();
            echo 'Message has been sent';
        } catch (Exception $e) {
            echo 'Message could not be sent. Mailer Error: ', $mail->ErrorInfo;
        }
    }
    
    header('Location:reset-password.php?message=<div class="alert alert-success"><img src="icon/accept.ico" style="width:24px; height:24px; border:0"/> Please check your email to change a new password !</div>');
}
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"> 
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
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
  <div class="container">
    <center><form method="POST" style="width: 70%">
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
        <input type="email" name="email" class="form-control" placeholder="Enter email">
      </div>
      <div style="float: right;">
        <button type="submit" name="send-mail-to-reset" class="btn btn-primary" style="width: 100px">Send</button>
      </div>
      <div style="float:left">
        <h6><a href="index.php" style="color: #084B8A; float:left; text-shadow: 2px 2px #F2F2F2F2; text-decoration:none">Back to Sign In</a></h6>
      </div>
    </form></center>
  </div>
</body>
</html>