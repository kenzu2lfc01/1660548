<?php
if (!isset($_SESSION['email']))
 header('Location: index.php');
if(isset($_SESSION['email']))
{
  if(isset($_POST['share']))
  {
    include 'connect.php';
    include 'functions.php';
    error_reporting(E_ALL);
    ini_set('display_errors', 1);

    $post = $_POST['post'];

    $privacy = $_POST['privacy'];

    $img_name = $_FILES['posted_image']['name'];

    if($post == '' && $img_name == '')
      return;

    $post = htmlentities($post);
    $img_name = htmlentities($img_name);

    $tmp = $_FILES['posted_image']['tmp_name'];

    if(!empty($img_name))
      $img_name = time() . $img_name;

    $new_path = 'img/' . $img_name;
	  
    move_uploaded_file($tmp, $new_path);

    resizeImage($new_path,782,550,false, $new_path);

    $query = $db->prepare("INSERT INTO posts(email,post,image,privacy,note) VALUES(?,?,?,?,?)");
    $query->execute([$_SESSION['email'],$post,$img_name,$privacy,'Posted']);
  }
  $currentUser = getCurrentUser();
}
?>
<!DOCTYPE>
<html>
<head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
  <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
  <style type="text/css">
  input:hover
  {
    opacity: 0.7;
  }
</style>

</head>
<body>
  <div class="container-fluid" style="margin-left: -20px; width: 103%; margin-top: -29px">
    <form method="POST" enctype="multipart/form-data">
      <div class="form-group">
        <div class="card" style="margin-bottom: -10px">
          <textarea class="form-control" autocomplete="on" name="post" style="height:150px" placeholder="What's on your mind?<?php echo getName($currentUser['fullname']); ?>"></textarea>
          <img id="output" height="150px" width="150px" class="img-fluid" style="border: 0; margin-left: 5px;"/>
          <script>
            var loadFile = function(event) {
              var output = document.getElementById('output');
              output.src = URL.createObjectURL(event.target.files[0]);
            };
          </script>
        </div>
      </div>
      <div>
        <button type="submit" name="share" style="float:right; margin-bottom: 20px; margin-top: 2px; width: 65px;" class="btn btn-primary">Share</button>
        <div class="form-group" style="float: left;">
          <input type="button" style="margin-top:2px; background-image:url('icon/image.ico');background-repeat: no-repeat;background-position: left bottom; text-align: right; width: 150px; margin-right: 5px; margin-left: 3px" value="Upload image" class="btn btn-success" onclick="document.getElementById('postedImage').click();" />
          <input type="file" name="posted_image" id="postedImage" accept="image/gif, image/jpeg, image/png" class="form-control" style="display: none" onchange="loadFile(event)">
          <label class="badge badge-info" style="height: 38px; margin-top: -50px; width: 130px">
            <img src="icon/shield.ico" style="border: 0; height: 32px; height: 32px;margin-left: -18px;"/>
            <div class="form-group" style="float: right; margin-left: -15px; margin-top: -2px">
              <select class="btn btn-info dropdown-toggle" name="privacy" id="exampleFormControlSelect1">
                <option>Public</option>
                <option>Friend</option>
                <option>Private</option>
              </select>
            </div>
          </label>
        </div>
      </div>
      <div>
      </div>
    </form>
  </div>
</body>
</html>