<?php
if (!function_exists('generateString')) {
	function generateString()
	{
		$arr = "a%^bcjopNOPQRSqrstuGHIJKM$#!@#!##@@@@vwyz0123&*()456defghi789ABCDEFklmnTUVWYZ!@#$";
		$str = null;    
		$len = strlen($arr);
		for($i = 0; $i < 9; $i++)
		{
			$rd = rand(0,$len);
			$str .= substr($arr, $rd, 1);
		}
		return $str;
	}
}
if(!function_exists('checkUserVerifyCode')) {
	function checkUserVerifyCode($email,$verifyCode) {
		global $db;
		$stmt = $db->prepare("SELECT * FROM userverifycodes WHERE email=? AND verifycode=?");
		$stmt->execute([$email,$verifyCode]);
		$result = $stmt->fetch(PDO::FETCH_ASSOC);
		if(!$result)
			return 0;
		else
		{
			if($result['status'] == 'unavailable')
				return -1;
			return 1;
		}
	}
}
if(!function_exists('checkIfEmailExisted')) {
	function checkIfEmailExisted($email) {
		global $db;
		$stmt = $db->prepare("SELECT * FROM users WHERE email=?");
		$stmt->execute([$email]);
		$result = $stmt->fetch(PDO::FETCH_ASSOC);
		if($result)
			return 1;
		return 0;
	}
}
if(!function_exists('confirmUserVerifyCode')) {
	function confirmUserVerifyCode($email,$verifyCode) {
		global $db;
		$query = $db->prepare("UPDATE userverifycodes SET status=? WHERE email=? AND verifycode=?");
		$query->execute(['unavailable',$email,$verifyCode]);
	}
}
if (!function_exists('getUserById')) {
	function getUserById($id)
	{
		global $db;
		$query = $db->prepare("SELECT * FROM users WHERE id=?");
		$query->execute([$id]);
		$user = $query->fetch(PDO::FETCH_ASSOC);
		return $user;
	}
}

if (!function_exists('findRelationship')) {
	function findRelationship($id1, $id2)
	{
		global $db;
		$query = $db->prepare("SELECT * FROM friends WHERE id1=? AND id2=? OR id1=? AND id2=?");
		$query->execute([$id1,$id2,$id2,$id1]);
		$count = 0;
		while($query->fetch(PDO::FETCH_ASSOC))
			$count++;
		return $count;
	}
}

if (!function_exists('findReciever')) {
	function findReciever($id1, $id2)
	{
		if(findRelationship($id1,$id2) == 1)
		{
			global $db;
			$q1 = $db->prepare("SELECT * FROM friends WHERE id1=? AND $id2=? AND reciever=?");
			$q1->execute([$id1,$id2,$id2]);
			$temp = $q1->fetch(PDO::FETCH_ASSOC);
			if($temp)
				return $id2;
			return $id1;
		}
		return -1;
	}
}

if (!function_exists('addFriend')) {
	function addFriend($id1, $id2)
	{
		global $db;
		$query = $db->prepare("INSERT INTO friends(id1,id2,reciever) VALUES(?,?,?)");
		$query->execute([$id1, $id2, $id2]);
	}
}

if (!function_exists('unfriend')) {
	function unfriend($id1, $id2)
	{
		global $db;
		$query = $db->prepare("DELETE FROM friends WHERE id1=? AND id2=? OR id1=? AND id2=?");
		$query->execute([$id1,$id2,$id2,$id1]);
	}
}

if (!function_exists('getName')) {
	function getName($fullname)
	{
		$i = strlen($fullname) - 1;
		$check = 0;
		while($i >= 0)
		{
			if($fullname[$i] == ' ')
			{
				$check = 1;
				break;
			}
			$i--;
		}
		if($check == 0)
			return $fullname;
		$i = strlen($fullname) - 1;
		while($fullname[$i] != ' ')
			$i--;
		return substr($fullname, $i);
	}
}

if (!function_exists('getCurrentUser')) {
	function getCurrentUser()
	{
		if(isset($_SESSION['email']))
		{
			global $db;
			$query = $db->prepare("SELECT * FROM users WHERE email=?");
			$query->execute([$_SESSION['email']]);
			$curUser = $query->fetch(PDO::FETCH_ASSOC);
			return $curUser;
		}
		return -1;
	}
}
if(!function_exists('search')) {
	function search($info) {
		$current_user = getCurrentUser();
		$countUsers = 0;
		$countPosts = 0;
		if($info == '')
		{
			echo '<h6 style="color:#084B8A; margin-top: 50px">There is no result.</h6>';
			return;
		}
		global $db;
		$name = '%'.$info.'%';
		$query = $db->prepare("SELECT * FROM users WHERE fullname LIKE ? OR phone = ? OR email = ?");
		$query->execute([$name,$info,$info]);
		echo '<h2 style="color:#084B8A; text-shadow: 2px 2px white;font-weight: bold; margin-top: 10px">Members</h2>';
		while($row=$query->fetch(PDO::FETCH_ASSOC)) {
			echo '<table style="margin-bottom: 20px;" border="2px" cellpadding="10px" width="100%">';
			echo '<tbody>';
			echo '<tr colspan="2" background="img/' . $row['wallpaper'] . '">';
			echo '<td>';
			echo '<div class="info">';
			echo '<div class="avatar" style="float:left; margin-left:10px">';
			echo '<a target="blank" href="personal.php?userid=' . $row['id'] . '" style="color:inherit; text-decoration:none"><img style="width: 170px; height: 170px; margin-top:25px; border: solid 6px white; border-radius:50%" src="img/' . $row['avatar'] . '" />';
			echo '</div>';
			echo '<div class="name" style="float:left; margin-top: 120px; margin-left:20px">';
			echo '<h1 style="color:white; text-shadow: 3px 3px black">' . $row['fullname'] . '</h1>';
			echo '</div>';
			echo '</div';
			echo '</td>';
			echo '</tr>';
			echo '</tbody>';
			echo '</table>';
			$countUsers++;
		}
		if($countUsers == 0)
			echo '<h6 style="color:#084B8A;">There is no result.</h6>';

		$keyword = '%'.$info.'%';
		$stmt = $db->prepare("SELECT * FROM users u JOIN posts p ON u.email = p.email AND p.post LIKE ? ORDER BY date DESC");
		$stmt->execute([$keyword]);

		echo '<hr/>';
		echo '<h2 style="color:#084B8A; text-shadow: 2px 2px white;font-weight: bold; margin-top: 20px; margin-bottom: -20px">Posts</h2>';
		while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
			if(checkPrivacy($row['postid']) == 'Public' && $row['id'] != $current_user['id']) {
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
			$countPosts++;
		}
		if($countPosts == 0)
			echo '<h6 style="color:#084B8A; margin-top:20px">There is no result.</h6>';
	}
}
if(!function_exists('countInvitations')) {
	function countInvitations() {
		$user = getCurrentUser();
		global $db;
		$count = 0;
		$stmt = $db->prepare("SELECT * FROM users");
		$stmt->execute();
		while($row = $stmt->fetch(PDO::FETCH_ASSOC))
		{
			if(findRelationship($user['id'],$row['id']) == 1 && findReciever($user['id'],$row['id']) == $user['id']) 
				$count++;
		}
		return $count;
	}
}
if(!function_exists('countUnreadMessages')) {
	function countUnreadMessages() {
		$user = getCurrentUser();
		global $db;
		$count = 0;
		$stmt = $db->prepare("SELECT * FROM messages WHERE recieverId=? and seen=?");
		$stmt->execute([$user['id'],$count]);
		while($stmt->fetch(PDO::FETCH_ASSOC))
			$count++;
		return $count;
	}
}
if(!function_exists('confirmMessages')) {
	function confirmMessages() {
		$user = getCurrentUser();
		global $db;
		$check = 1;
		$stmt = $db->prepare("UPDATE messages SET seen=? WHERE recieverId=?");
		$stmt->execute([$check,$user['id']]);
	}
}
if (!function_exists('addPost')) {
	function addPost($post,$image,$privacy,$note)
	{
		global $db;
		$query = $db->prepare("INSERT INTO posts(email,post,image,privacy,note) VALUES(?,?,?,?,?)");
		$query->execute([$_SESSION['email'], $post, $image, $privacy, $note]);
	}
}
if(!function_exists('reactPost')) {
	function reactPost($postId, $reaction) {
		$user = getCurrentUser();
		global $db;
		$stmt = $db->prepare("INSERT INTO postreactions(postid,reactorid,reaction) VALUES(?,?,?)");
		$stmt->execute([$postId,$user['id'],$reaction]);
	}
}
if(!function_exists('dontReactPost')) {
	function dontReactPost($postId, $reaction) {
		$user = getCurrentUser();
		global $db;
		$stmt = $db->prepare("DELETE FROM postreactions WHERE postid=? and reactorid=? and reaction=?");
		$stmt->execute([$postId,$user['id'],$reaction]);
	}
}
if(!function_exists('countPostReactions')) {
	function countPostReactions($postId,$reaction) {
		global $db;
		$stmt = $db->prepare("SELECT COUNT(*) AS numbers FROM postreactions WHERE postid=? AND reaction=?");
		$stmt->execute([$postId,$reaction]);
		$numbers = $stmt->fetch(PDO::FETCH_ASSOC);
		return $numbers['numbers'];
	}
}
if(!function_exists('isLiked')) {
	function isLiked($postId) {
		$user = getCurrentUser();
		global $db;
		$stmt = $db->prepare("SELECT * FROM postreactions WHERE postid=? AND reactorid=? AND reaction=?");
		$stmt->execute([$postId, $user['id'], 'like']);
		$check = $stmt->fetch(PDO::FETCH_ASSOC);
		if($check)
			return 1;
		return 0;
	}
}
if(!function_exists('countFriends')) {
	function countFriends($userId) {
		$user = getUserById($userId);
		global $db;
		$stmt = $db->prepare("SELECT * FROM users");
		$stmt->execute();
		$count = 0;
		while($row = $stmt->fetch(PDO::FETCH_ASSOC))
			if(findRelationship($user['id'],$row['id']) == 2)
				$count++;
			return $count;
		}
	}
	if(!function_exists('postComment')) {
		function postComment($postId,$comment) {
			$user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("INSERT INTO postreactions(postid,reactorid,reaction,comment) VALUES(?,?,?,?)");
			$stmt->execute([$postId,$user['id'],'comment',$comment]);
		}
	}
//Referrence source: https://stackoverflow.com/questions/14649645/resize-image-in-php
	if(!function_exists('resizeImage')) {
		function resizeImage($file, $w, $h, $crop=FALSE,$output) 
		{
			list($width, $height) = getimagesize($file);
			$r = $width / $height;
			if ($crop) {
				if ($width > $height) {
					$width = ceil($width-($width*abs($r-$w/$h)));
				} else {
					$height = ceil($height-($height*abs($r-$w/$h)));
				}
				$newwidth = $w;
				$newheight = $h;
			} else {
				if ($w/$h > $r) {
					$newwidth = $h*$r;
					$newheight = $h;
				} else {
					$newheight = $w/$r;
					$newwidth = $w;
				}
			}
			$src = imagecreatefromjpeg($file);
			$dst = imagecreatetruecolor($newwidth, $newheight);
			imagecopyresampled($dst, $src, 0, 0, 0, 0, $newwidth, $newheight, $width, $height);
			imagejpeg($dst, $output);
		}
	}

	if(!function_exists('displayComments')) {
		function displayComments($postId) {
			global $db;
			$stmt = $db->prepare("SELECT * FROM postreactions WHERE postid=? AND reaction=? ORDER BY reactionDate ASC");
			$stmt->execute([$postId,'comment']);
			
			while($row = $stmt->fetch(PDO::FETCH_ASSOC))
			{
				$reactor = getUserById($row['reactorid']);
				echo '<div class="card" style="width:100%; margin-bottom:-5px; margin-top:10px">';
				echo '<div class="card-header">';
				echo '<h6 style="color: #084B8A; text-shadow: 2px 2px #E6E6E6"><a href="personal.php?userid=' . $reactor['id'] . '" style="color:inherit; text-decoration:none;" target="blank"><img src="img/' . $reactor['avatar'] . '" width="51px" height="51px" style="border: solid 2px white; margin-right: 5px; border-radius: 50%"/>' . $reactor['fullname'] . '</a></h6>';
				echo '<hr />';
				echo '<p class="card-text" style="font-size: 13px">Commented on post at '.$row['reactionDate'].'</p>';
				echo '<h6 style="margin-bottom: 20px">'.$row['comment'].'</h6>';
				echo '</div>';
				echo '</div>';
				
			}
		}
	}
	if(!function_exists('removePost')) {
		function removePost($postId) {
			global $db;
			$stmt = $db->prepare("DELETE FROM posts WHERE postid=?");
			$stmt->execute([$postId]);
			$stmt = $db->prepare("DELETE FROM postreactions WHERE postid=?");
			$stmt->execute([$postId]);
		}
	}
	if(!function_exists('checkPrivacy')) {
		function checkPrivacy($postId) {
			global $db;
			$stmt = $db->prepare("SELECT * FROM posts WHERE postid=?");
			$stmt->execute([$postId]);
			$res = $stmt->fetch(PDO::FETCH_ASSOC);
			return $res['privacy'];
		}
	}
	if(!function_exists('listUsersLikePost')) {
		function listUsersLikePost($postId) {
			global $db;
			$stmt = $db->prepare("SELECT u.* FROM users u JOIN postreactions p ON id = reactorid AND reaction=? WHERE postid=?");
			$stmt->execute(['like',$postId]);
			while($row = $stmt->fetch(PDO::FETCH_ASSOC))
			{
				echo '<a class="dropdown-item" href="#" style="width:100%" target="blank">';
				$row = getUserById($row['id']);
				echo '<div class="card" style="width:100%; margin-top:-15px; margin-bottom:10px">';
				echo '<div class="card-text">';
				echo '<h6 style="color: #084B8A; text-shadow: 2px 2px #E6E6E6"><a href="personal.php?userid=' . $row['id'] . '"style="color:inherit; text-decoration:none;" target="blank"><img src="img/' . $row['avatar'] . '" width="48px" height="48px" style="border: solid 3px white; margin-right: 5px; border-radius: 50%"/>' . $row['fullname'] . '</a></h6>';
				echo '</div>';
				echo '</div>';
				echo '</a>';
			}
		}
	}
	if(!function_exists('showAlerts')) {
		function showAlerts() {
			$current_user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("SELECT * FROM postreactions pr JOIN posts p on pr.postid = p.postid AND email=? AND reactorid <> ? ORDER BY reactionDate DESC");
			$stmt->execute([$current_user['email'],$current_user['id']]);
			while($row = $stmt->fetch(PDO::FETCH_ASSOC))
			{
				$user = getUserById($row['reactorid']);
				echo '
				<li style="background: white"><a href="personal-post.php?alerted_post='.$row['postid'].'" style="color:black; text-decoration:none"><div class="card-body" style="width:100%">
				<h6>';

				echo '<img src="img/'.$user['avatar'].'" style="border-radius:50%; height:51px; width:51px"/><strong> '.$user['fullname'].'</strong> '.$row['reaction'];
				if($row['reaction'] == 'like')
					echo 'd ';
				else if($row['reaction'] == 'comment')
					echo 'ed on ';
				echo ' your post at '.$row['reactionDate'];

				echo '</h6>
				</div></a><li>';
			}
		}
	}
	if(!function_exists('increaseAlertNumbers')) {
		function increaseAlertNumbers($email) {
			$current_user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("UPDATE users SET alerts = alerts + ? WHERE email = ? AND email <> ?");
			$stmt->execute([1,$email,$current_user['email']]);
		}
	}
	if(!function_exists('decreaseAlertNumbers')) {
		function decreaseAlertNumbers($email) {
			$current_user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("UPDATE users SET alerts = alerts - ? WHERE email = ? AND email <> ?");
			$stmt->execute([1,$email,$current_user['email']]);
		}
	}
	if(!function_exists('getAlertNumbers')) {
		function getAlertNumbers($email) {
			$current_user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("SELECT * from users WHERE email =?");
			$stmt->execute([$current_user['email']]);
			return $current_user['alerts'];
		}
	}
	if(!function_exists('confirmAlerts')) {
		function confirmAlerts() {
			$current_user = getCurrentUser();
			global $db;
			$stmt = $db->prepare("UPDATE users SET alerts = ? WHERE email = ?");
			$stmt->execute([0, $current_user['email']]);
		}
	}
	?>