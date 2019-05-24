<?php
session_start();
include 'functions.php';
include 'connect.php';
if (!isset($_SESSION['email']))
	header('Location: index.php');
$current_user = getCurrentUser();
if(isset($_POST['submit']))
{
	error_reporting(E_ALL);
	ini_set('display_errors', 1);
	include 'connect.php';
	
	$fullname = $_POST['fullname'];
	$phone = $_POST['phone'];
	$company = $_POST['company'];
	$img_name = $_FILES['user_img']['name'];
	$wall = $_FILES['wallpaper']['name'];
	$intro = $_POST['intro'];
	
	$fullname = htmlentities($fullname);
	$phone = htmlentities($phone);  
	$company = htmlentities($company);
	$img_name = htmlentities($img_name);
	$wall = htmlentities($wall);

	if(!empty($img_name))
	{
		$tmp = $_FILES['user_img']['tmp_name'];
		$img_name = time() . $img_name;
		$new_path = 'img/' . $img_name;

		if(!move_uploaded_file($tmp, $new_path))
		{
			header('Location: account.php?message=<div class="alert alert-success">Upload image failed !</div>');
		}
		else
		{
			move_uploaded_file($tmp, $new_path);
			$query = $db->prepare("UPDATE users SET avatar=? WHERE email=?");
			$query->execute([$img_name,$_SESSION['email']]);
			addPost('',$img_name,'Friend','Changed avatar');
		}
	}
	if(!empty($wall))
	{
		$tmp = $_FILES['wallpaper']['tmp_name'];
		$wall = time() . $wall;
		$new_path = 'img/' . $wall;

		if(!move_uploaded_file($tmp, $new_path))
		{
			header('Location: account.php?message=<div class="alert alert-success"><img src="icon/refuse.ico" style="height:24px; width:24px; border:0"/> Upload wallpaper failed !</div>');
		}
		else
		{
			move_uploaded_file($tmp, $new_path);
			$query = $db->prepare("UPDATE users SET wallpaper=? WHERE email=?");
			$query->execute([$wall,$_SESSION['email']]);
			addPost('',$wall,'Friend','Changed wallpaper');
		}
	}
	$query = $db->prepare("UPDATE users SET fullname=?, phone=?, company=?, introduction=? WHERE email=?");
	$query->execute([$fullname,$phone,$company,$intro,$_SESSION['email']]);
	header('Location: account.php?message=<div class="alert alert-success"><img src="icon/accept.ico" style="height:24px; width:24px; border:0"/> Update profile successfully !</div>');
}
?>
<!DOCTYPE>
<html>
<head>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
	<meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />
	<link rel="shortcut icon" href="icon/tuebook.ico" />
	<title>Account</title>
	<style>
	.container-fluid h4
	{
		text-shadow: 2px 2px #e6e6e6e6;
	}
	h6:hover
	{
		font-weight: bold;
	}
</style>
</head>
<?php include 'welcome-header.php'; ?>
<body style="background:#E6E6E6;">
	<div class="container-fluid" style="margin-left:none">
		<form method="POST" enctype="multipart/form-data" style="background-color: white; height: 135%">
			<div class="profile" style="width: 90%; height: 90%">
				<div class="avatar" style="float:left; margin-left: 30px">
					<!--<img style="width: 200px; height: 200px; margin-top:25px; border: solid 6px #E6E6E6;" src="img/<?php //echo $current_user['avatar']; ?>"/>-->

					<img id="avatar" class="img-fluid" style="width: 200px; height: 200px; margin-top:25px; border: solid 6px #E6E6E6;" src="img/<?php echo $current_user['avatar']; ?>"/>
					<script>
						var loadAvatar = function(event) {
							var output = document.getElementById('avatar');
							output.src = URL.createObjectURL(event.target.files[0]);
						};
					</script>
					
					<div class="browse-avt" style="position: absolute;">
						<input type="button" value="Upload" class="btn btn-primary" onclick="document.getElementById('fileToUpload').click();" style="margin-top:-200px; background-image:url('icon/upload.ico');background-repeat: no-repeat;background-position: left top; text-align: right; width: 90px;background-size: 24px 24px"/>
						<input type="file" style="display:none;" id="fileToUpload" name="user_img" accept="image/gif, image/jpeg, image/png" onchange="loadAvatar(event)"/>

					</div>
					<div class="form-group">
						<input type="file" name="wallpaper" id="wallpaperImage" accept="image/gif, image/jpeg, image/png" class="form-control" style="display: none" onchange="loadWallpaper(event)">
						<br/><a href="change-password.php" style="color:white;text-decoration: none;"><label style="margin-top: 30px; width: 200px" class="btn btn-info" style="text-decoration:none"><img src="icon/lock.ico" style="width:32px;height:32px;margin-top:-5px"/> Change password</</label></a>
					</div>
				</div>
				<div class="profile" style="float:right; width: 78%; margin-top: 15px">
					<h1 style="color:#084B8A; text-shadow: 2px 2px #e6e6e6e6">Profile</h1>
					<?php
					if(isset($_GET['message']))
					{
						$message = $_GET['message'];
						unset($_GET['message']);
						echo $message;
					}
					?>
					<h4 style="color:#084B8A">Full name</h4>
					<div class="form-group">
						<input type="text" name="fullname" class="form-control" value="<?php echo $current_user['fullname']; ?>">
					</div>
					<h4 style="color:#084B8A">Phone number</h4>
					<div class="form-group">
						<input type="text" name="phone" class="form-control" value="<?php echo $current_user['phone']; ?>">
					</div>
					<h4 style="color:#084B8A">Company</h4>
					<div class="form-group">
						<input type="text" name="company" class="form-control" value="<?php echo $current_user['company']; ?>">
					</div>
					<h4 style="color:#084B8A">Introduction</h4>
					<div class="form-group">
						<textarea name="intro" class="form-control"><?php echo $current_user['introduction']; ?></textarea>
					</div>
					<h4 style="color:#084B8A">Wallpaper</h4>
					<img id="wallpaper" class="img-fluid" style="width: 100%; height: 250px; border: solid 6px #E6E6E6;" src="img/<?php echo $current_user['wallpaper']; ?>"/>
					<script>
						var loadWallpaper = function(event) {
							var output = document.getElementById('wallpaper');
							output.src = URL.createObjectURL(event.target.files[0]);
						};
					</script>
					<input type="button" style="background-image:url('icon/upload.ico');background-repeat: no-repeat;background-position: left top; text-align: right; width: 90px; margin-top: -250px; background-size: 24px 24px" value="Upload" class="btn btn-primary" onclick="document.getElementById('wallpaperImage').click();" />
					<button type="submit" name="submit" class="btn btn-success" style="width:100%; margin-top: 10px">Update</button>
				</div>
			</div>
		</form>
	</div>
</body>
</html>
