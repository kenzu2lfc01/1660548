<?php
session_start();
include 'connect.php';
include 'functions.php';
if(!isset($_SESSION['email']))
  header('location: index.php');
if(isset($_POST['refuse']) || isset($_POST['accept'])) 
  header('location: friend.php');
$current_user = getCurrentUser();
confirmMessages();
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <?php
  if (isset($_SESSION['email']))
  {
    echo '
    <title>Messages</title>';
  }
  else
  {
    header('location: index.php');
  }
  ?>
  <style>
  h6:hover
  {
    font-weight: bold;
  }
  .card{
    margin-right:50%;
    margin-top:30px;
    margin-top: 25px;
  }
  .card h3:hover
  {
    text-shadow: 1px 1px #eee;
    font-weight: bold;
  }
  .card-header img:hover
  {
    opacity: 0.8;
  }
</style>
</head>
<body style="background:#E6E6E6">
  <?php include 'welcome-header.php'; ?>
  <div class="container">     
    <?php
    $query = $db->prepare("SELECT * from messages WHERE recieverId = ? ORDER BY date DESC");
    $query->execute([$current_user['id']]);
    while($row = $query->fetch(PDO::FETCH_ASSOC))
    {
      $sender = getUserById($row['senderId']);
      echo '<div class="card" style="width:100%; margin-bottom:-10px; margin-left: -2px">';
      echo '<div class="card-header">';
      echo '<table cellpadding="5">';
      echo '<tbody>';
      echo '<tr>';     
      echo '<td>';
      echo '<a target="blank" href="personal.php?userid=' . $sender['id'] . '" style="color:inherit; text-decoration:none"><img style="width: 75px; height: 75px; border-radius:50%; border:solid 3px white" src="img/'. $sender['avatar'] . '" /></a>';
      echo '</td>';
      echo '<td>';
      echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a target="blank" href="personal.php?userid=' . $sender['id'] . '" style="color:inherit; text-decoration:none">' . $sender['fullname'] . '</a></h3>';
      echo '</td>';
      echo '</tr>';
      echo '</tbody>';
      echo '</table>';
      echo '</div>';
      echo '<div class="card-body"><p class="card-title">Sent at '. $row['date'] . '</p>';
      echo '<h5><p class="card-text">';
      echo $row['message'];
      echo '</p></h5>';
      echo '</div>';
      echo '</div>';
    }
    ?>
  </div>
</body>
</html>
