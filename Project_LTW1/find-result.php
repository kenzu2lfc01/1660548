<?php
session_start();
include 'connect.php';
include 'functions.php';
if(!isset($_SESSION['email']))
	header('location: index.php');
if(isset($_GET['find-submit']))
{
  if(isset($_GET['info']))
    $info = $_GET['info'];
}
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
?>

<!DOCTYPE>
<html>
<head>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <link rel="shortcut icon" href="icon/tuebook.ico" />
  <title>Searching</title>
  <style>
  .card{
    margin-right:50%;
    margin-top:30px
  }
  li:hover { 
    background-color: blue;
  }
  tr {
    background-size: cover;
  }
  table h1:hover
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
<body style="background:#e6e6e6e6">
  <?php include 'welcome-header.php'; ?>   
  <div class="container">   
    <?php
    if(isset($_GET['info']))
    {
      $info = $_GET['info'];
      $info = htmlentities($info);
      search($info);
    }
    ?>
  </div>
</body>
</html>