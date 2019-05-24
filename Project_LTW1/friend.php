<?php
session_start();
include 'connect.php';
include 'functions.php';
if(!isset($_SESSION['email']))
  header('location: index.php');
/*if(isset($_POST['cancel']) || isset($_POST['accept']))// || isset($_POST['unfriend-in-friendlist'])) 
header('location: friend.php');*/
$current_user = getCurrentUser();
$stmt = $db->prepare("SELECT * FROM users");
$stmt->execute();
while($row = $stmt->fetch(PDO::FETCH_ASSOC))
{
  if(isset($_POST['accept']) && $_POST['accept'] == $row['id'])
    addFriend($current_user['id'],$row['id']);
  if(isset($_POST['button-suggestions']) && $_POST['button-suggestions'] == $row['id'].'-addfriend')
    addFriend($current_user['id'],$row['id']);
  if(isset($_POST['button-suggestions']) && $_POST['button-suggestions'] == $row['id'].'-cancel-invitation')
    unfriend($current_user['id'],$row['id']);
  if(isset($_POST['cancel']) && $_POST['cancel'] == $row['id'])
    unfriend($row['id'],$current_user['id']);
  if(isset($_POST['unfriend-in-friendlist']) && $_POST['unfriend-in-friendlist'] == $row['id'])
  {
    unfriend($row['id'],$current_user['id']);
    unfriend($current_user['id'],$row['id']);
  }
}
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
    <title>Friends</title>';
  }
  else
  {
    header('location: index.php');
  }
  ?>
  <style>
  .card{
    margin-right:50%;
    margin-top:30px;
  }
  li:hover { 
    background-color: blue;
  }
  tr {
    background-size: cover;
  }
  .card h3:hover
  {
    font-weight: bold;
  }
  .card-header img:hover
  {
    opacity: 0.8;
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
<body style="background:#E6E6E6">
  <?php include 'welcome-header.php'; ?>
  </div>
  <div class="container">     
    <div id="accordion">
      <div class="card" style="width: 100%">
        <div class="card-header" id="headingOne">
          <h5 class="mb-0">
            <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne" style="text-decoration: none">
              <?php
              $query = $db->prepare("SELECT * FROM friends WHERE id2=?");
              $query->execute([$current_user['id']]);
              $invitations = countInvitations();
              echo '<h3 style="color:#084B8A; text-shadow: 2px 2px white;font-weight: bold;"">Invitations ('.$invitations.')</h3>';
              ?>
            </button>
          </h5>
        </div>
        <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
          <div class="card-body">
           <?php
           if(countInvitations() == 0)
            echo '<h6 style="color:#084B8A;">There is no invitation.</h6>';
          while($row = $query->fetch(PDO::FETCH_ASSOC))
          {
            $inviter = getUserById($row['id1']);
            if(findRelationship($current_user['id'],$inviter['id']) == 1)
            {
              echo '<div class="card" style="width:100%;">';
              echo '<div class="card-header">';
              echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a href="personal.php?userid=' . $inviter['id'] . '" style="color:inherit; text-decoration:none"><img src="img/' . $inviter['avatar'] . '" width="75px" height="75px" style="border: solid 3px white; margin-right: 5px; border-radius: 50%"/>' . $inviter['fullname'] . '</a></h3>';
              echo '<form method="POST">';
              echo '<div style="float:right; margin-top:10px">';
              echo '<button type="submit" class="btn btn-danger" value="'.$inviter['id'].'"name="cancel" width="155px" style="float:right; margin-left: 5px"><img src="icon/refuse.ico" width="24px" height="24px" style="border:0"/> Cancel</button>';
              echo '<div style="float:left; margin-top:-23px">';
              echo '<br/><button type="submit" class="btn btn-success" value="'.$inviter['id'].'"name="accept" width="150px" style="float:right"><img src="icon/accept.ico" width="24px" height="24px" style="border:0"/> Accept</button>';
              echo '</div>';
              echo '</div>';
              echo '</form>';
              echo '</div>';
              echo '</div>';
            }
          }
          ?>
        </div>
      </div>
    </div>
    <div class="card" style="width: 100%">
      <div class="card-header" id="headingTwo">
        <h5 class="mb-0">
          <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" style="text-decoration: none">
            <?php
            $stmt = $db->prepare("SELECT * FROM users WHERE id <> ?");
            $stmt->execute([$current_user['id']]);
            $friends = countFriends($current_user['id']);
            echo '<h3 style="color:#084B8A; text-shadow: 2px 2px white;font-weight:bold">Friends ('.$friends.')</h3>';
            ?>
          </button>
        </h5>
      </div>
      <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
        <div class="card-body">
          <?php 
          while($row = $stmt->fetch(PDO::FETCH_ASSOC))
          {
            if(findRelationship($current_user['id'],$row['id']) == 2)
            {
              echo '<div class="card" style="width:100%; margin-top:-5px; margin-bottom:10px">';
              echo '<div class="card-header">';
              echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a href="personal.php?userid=' . $row['id'] . '" style="color:inherit; text-decoration:none"><img src="img/' . $row['avatar'] . '" width="75px" height="75px" style="border: solid 3px white; margin-right: 5px; border-radius: 50%"/>' . $row['fullname']. '</a></h3>';
              echo '<form method="POST">';
              echo '<button type="submit" class="btn btn-danger" value="'.$row['id'].'" name="unfriend-in-friendlist" width="155px" style="float:right; margin-left: 5px"><img src="icon/unfriend.ico" width="24px" height="24px" style="border:0"/> Unfriend</button>';
              echo '</form>';
              echo '</div>';
              echo '</div>';
            }
          }
          ?>
        </div>
      </div>
    </div>
    <div class="card" style="width: 100%">
      <div class="card-header" id="headingThree">
        <h5 class="mb-0">
          <button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree" style="text-decoration: none">
            <?php
            echo '<h3 style="color:#084B8A; text-shadow: 2px 2px white;font-weight:bold">Suggestions</h3>';
            ?>
          </button>
        </h5>
      </div>
      <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
        <div class="card-body">
          <?php
          $stmt = $db->prepare("SELECT * FROM users WHERE id <> ?");
          $stmt->execute([$current_user['id']]);
          while($row2 = $stmt->fetch(PDO::FETCH_ASSOC))
          {
            if(findRelationship($current_user['id'], $row2['id']) == 0)
            {
             
                echo '<div class="card" style="width:100%; margin-top:-5px; margin-bottom:10px">';
                echo '<div class="card-header">';
                echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a href="personal.php?userid=' . $row2['id'] . '" style="color:inherit; text-decoration:none"><img src="img/' . $row2['avatar'] . '" width="75px" height="75px" style="border: solid 3px white; margin-right: 5px; border-radius: 50%"/>' . $row2['fullname']. '</a></h3>';
                echo '<form method="POST">';

                $check = findRelationship($current_user['id'],$row2['id']);
        
                if($check == 0)
                {
                  echo '<button type="submit" class="btn btn-success" value="'.$row2['id'].'-addfriend'.'" name="button-suggestions" width="155px" style="float:right; margin-left: 5px"><img src="icon/addfriend.ico" width="24px" height="24px" style="border:0"/> Add friend</button>';
                }
                else 
                {
                  echo '<button type="submit" class="btn btn-danger" value="'.$row2['id'].'-cancel-invitation'.'" name="button-suggestions" width="155px" style="float:right; margin-left: 5px"><img src="icon/refuse.ico" width="24px" height="24px" style="border:0"/> Cancel invitation</button>';
                }
                echo '</form>';
                echo '</div>';
                echo '</div>';
              }
        }
        ?>
      </div>
    </div>
  </div>
</div>
</div>
</body>
</html>