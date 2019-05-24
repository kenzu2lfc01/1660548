<?php
session_start();
include 'connect.php';
include 'functions.php';
if(!isset($_SESSION['email']))
  header('location: index.php');
$query = $db->prepare("SELECT * FROM posts");
$query->execute();
while($post = $query->fetch(PDO::FETCH_ASSOC))
{
  $postid = $post['postid'];
  if(isset($_POST['emotion-post']) && $_POST['emotion-post'] == $post['postid'].'-like')
  {
    reactPost($post['postid'],'like');
    increaseAlertNumbers($post['email']);
  }
  if(isset($_POST['emotion-post']) && $_POST['emotion-post'] == $post['postid'].'-dislike')
  {
    dontReactPost($post['postid'],'like');
    decreaseAlertNumbers($post['email']);
  }
  if(isset($_POST['post-comment-button']) && $_POST['post-comment-button'] == $post['postid']
    && isset($_POST[$postid]) && $_POST[$postid] != '')
  {
    postComment($post['postid'],$_POST[$postid]);
    increaseAlertNumbers($post['email']);
  }
  if(isset($_POST['remove-post']) && $_POST['remove-post'] == $post['postid'])
    removePost($post['postid']);
}
$current_user = getCurrentUser();
if(isset($_GET['alerted_post']))
  $alerted_post = $_GET['alerted_post'];
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Personal post</title>
  <style>
  .card button:hover
  {
    box-shadow: 2px 2px gray;
    opacity: 0.6;
  }
  .card
  {
    margin-top: 20px;
    margin-bottom: 50px;
  }
  .card button
  {
    height: 50px;
    width: 100px;
  }
  .card-header img:hover
  {
    opacity: 0.8;
  }
  .card h3:hover
  {
    text-shadow: 1px 1px #eee;
    font-weight: bold;
  }
  .card h6:hover
  {
    font-weight: bold;
  }
  img
  {
    border: solid 4px white;
  }
  .dropdown-menu h6 a:hover
  {
    font-weight: bold;
  }
  ul li:hover
  {
    font-weight: bold;
    color: #084B8A;
  }
  a
  {
    color: black;
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
  <div class="container">     
    <?php
    if(isset($_SESSION['email'])) {
      $stmt = $db->prepare("SELECT * FROM users u JOIN posts p ON u.email = p.email ORDER BY date DESC");
      $stmt->execute();
      while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        if($row['postid'] == $alerted_post) {
          if(findRelationship($current_user['id'],$row['id']) == 2 && checkPrivacy($row['postid']) != 'Private' || $row['id'] == $current_user['id']) {
            echo '<div class="card" style="width:100%; margin-bottom:-5px; margin-left: -2px;">';
            echo '<div class="card-header">';
            echo '<table cellpadding="5">';
            echo '<tbody>';
            echo '<tr>';     
            echo '<td>';
            if($row['email'] != $_SESSION['email'])
            {
              echo '<a target="blank" href="personal.php?userid=' . $row['id'] . '" style="color:inherit; text-decoration:none"><img style="width: 75px; height: 75px; border-radius:50%" src="img/'. $row['avatar'] . '" /></a>';
              echo '</td>';
              echo '<td>';
              echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a target="blank" href="personal.php?userid=' . $row['id'] . '" style="color:inherit; text-decoration:none">' . $row['fullname'] . '</a></h3>';

              $privacy = checkPrivacy($row['postid']);
              if($privacy == 'Public')
                echo '<h6><img src="icon/earth.ico" style="border:0; width:24px; height:24px"/> Public</h6>';
              else if($privacy == 'Friend')
                echo '<h6><img src="icon/friend_blue.ico" style="border:0; width:28px; height:28px"/> Friend</h6>';

              echo '</td>';
            }
            else
            {
              echo '<a href="home.php" style="color:inherit; text-decoration:none"><img style="width: 75px; height: 75px;border-radius:50%" src="img/'. $row['avatar'] . '" /></a>';
              echo '</td>';
              echo '<td>';
              echo '<h3 style="color: #084B8A; text-shadow: 3px 3px #E6E6E6"><a href="home.php" style="color:inherit; text-decoration:none">' . $row['fullname'] . '</a></h3>';

              $privacy = checkPrivacy($row['postid']);
              if($privacy == 'Public')
                echo '<h6><img src="icon/earth.ico" style="border:0; width:24px; height:24px"/> Public</h6>';
              else if($privacy == 'Friend')
                echo '<h6><img src="icon/friend_blue.ico" style="border:0; width:28px; height:28px"/> Friend</h6>';
              else
                echo '<h6><img src="icon/lock_blue.ico" style="border:0; width:24px; height:24px"/> Private</h6>';

              echo '</td>';
            }
            echo '</tr>';
            echo '</tbody>';
            echo '</table>';
            if($current_user['id'] == $row['id'])
             echo '
           <form method="POST" style="float:right; margin-top:-115px; margin-right:-12px">
           <br/><button class="btn btn-default" name="remove-post" type="submit" value="'.$row['postid'].'" style="height:32px; width:32px; background-color:#F2F2F2F2"><img src="icon/refuse.ico" style="border:0; width:24px; height:24px; margin-left:-8px"/></button>
           </form>';  
           echo '</div>';
           echo '<div class="card-body"><p class="card-title">'.$row['note'].' at '. $row['date'] . '</p>';
           echo '<h5><p class="card-text" style="margin-bottom: 20px">';
           echo $row['post'];
           if(!empty($row['image']))
            echo '<br/><img src="img/'. $row['image'] .'" class="img-fluid">';

          $likes = countPostReactions($row['postid'],'like');
          $comments = countPostReactions($row['postid'],'comment');;
          $shares = countPostReactions($row['postid'],'share');;

          echo '<h6><p class="card-title" style="font-weight: normal; margin-left: 5px;">';

          echo '
          <div class="row">
          <div class="col">
          '.$likes.'<a href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="text-decoration:none; color:black">
          <img src="icon/like_black.ico" style="height:32px; width:32px"/> Likes
          </a>';

          echo '<div class="dropdown-menu" aria-labelledby="dropdownMenuLink" style="width:50%;height:100%">';

          echo listUsersLikePost($row['postid']);

          echo '
          </div>
          </div>';

          echo '
          <div class="col-md-auto">
          '.$comments.' <img src="icon/comment_black.ico" style="height:32px; width:32px"/>Comments
          </div>
          <div class="col col-lg-2">
          '.$shares.' <img src="icon/share_black.ico" style="height:32px; width:32px"/>Shares
          </div>
          </div>';

          echo '</p></h6>';

          echo '<hr style="margin-top: -5px"/><br/>';

          echo '</p></h5>';

          echo '<form method="POST" style="margin-top: -105px; margin-bottom: -15px">';

          echo '
          <div class="dropup1">';

          $check = isLiked($row['postid']);
          echo '<br/><br/><button name="emotion-post" value="';
          if($check == 0)
            echo $row['postid'].'-like';
          else echo $row['postid'].'-dislike';
          echo '" type="submit" style="margin-top:10px;margin-bottom:0px; background:white"class="btn btn-default">';

          if($check == 0)
            echo '<h6 style="font-weight: normal"><img src="icon/like.ico" style="border:0" /> Like</h6></button>';
          else echo '<h6 style="color: #084B8A; font-weight:bold"><img src="icon/liked.ico" style="border:0" /> Like</h6></button>';

          echo '
          <button class="btn btn-default" name="collapse-comments" type="button" data-toggle="collapse" data-target="#'.$row['postid'].'" aria-expanded="false" aria-controls="collapseExample" style="margin-top:10px;margin-bottom:0px;margin-left:3px;background:white; width:125px" class="btn btn-default"><h6 style="font-weight: normal"><img src="icon/comment.ico" style="border:0" /> Comment</h6></button>
          ';

          echo'<button class="btn btn-default" type="button" data-toggle="dropdown" style="margin-top:10px;margin-bottom:0px;margin-left:3px;background:white;"><h6 style="font-weight: normal"><img src="icon/share.ico" style="border:0" /> Share</h6><span class="caret"></span></button>
          <ul class="dropdown-menu" style="background-color: white">
          <li style="background-color: white; margin-left: 5px"><a href="index.php" style="text-decoration:none;"> Send as message</a></li>
          <li style="background-color: white; margin-left: 5px"><a href="index.php" style="text-decoration:none;"> Share with friends</a></li>
          <li style="background-color: white; margin-left: 5px"><a href="index.php" style="text-decoration:none;"> Share only me</a></li>
          </ul>
          </div>';

          echo '<hr style="margin-top:2px"/>';
          echo '
          <div class="form-group">
          <img src="img/'.$current_user['avatar'].'" style="width:48px;height:48px;border-radius:50%"/>

          <textarea class="form-control" autocomplete="on" name="'.$row['postid'].'" style="width:95%;height:90px;float:right;background-color:#FAFAFA" placeholder="Comment..."></textarea>

          <button type="submit" class="btn btn-primary" value="'.$row['postid'].'" name="post-comment-button" style="float:right;margin-top:10px;margin-bottom:10px;width:100px;height:38px">Post</button>';

          echo '</div>';
          echo '</form>';

          if($comments > 0)
          {
            echo '<div class="collapse" id="'.$row['postid'].'" style="width:100%;">';

            displayComments($row['postid']);

            echo '</div>';
          }

          echo '</div>';
          echo '</div>';
        }
      }
    }
  }
  ?>
</div>
</body>
</html>
