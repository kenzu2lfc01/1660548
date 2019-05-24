<?php
include 'connect.php';
include 'functions.php';
?>
<!DOCTYPE>
<html>
<head>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
 <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
 <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
 <meta httmp-equiv="Content-Type" content="text/html;charset=UTF-8" />

 <style>
 .navbar ul li a:hover { 
  background-color: #084B8A;
}
.navbar h4
{
  font-weight: bold;
}
.navbar img:hover
{
  opacity: 0.9;
}
.navbar h4:hover
{
  opacity: 0.9;
}
.navbar h1:hover
{
  opacity: 0.9;
}
.navbar-brand
{
  text-shadow: 4px 4px black;
}
.navbar
{
  background: #084B8A;
}
.nav-link
{
  color: white;
}
.navbar-expand-lg
{
  box-shadow: 3px 3px black;
}
.navbar-dark
{
  text-shadow: 2px 2px black;
  font-weight: bold;
}
h4
{
  margin-top:10px;
}
.navbar h1
{
  font-weight: bold;
  color: white;
  font-size: 50px;
}
.navbar-brand img
{
  width: 64px;
  height: 64px;
}
button {
  background-color: Transparent;
  background-repeat:no-repeat;
  border: none;
  cursor:pointer;
  overflow: hidden;
  outline:none;
}
button:hover
{
  border: 0;
}
h6
{
  text-shadow: 0px 0px;
}
</style>
<script type="text/javascript">
  //Prevent form from resubmission
  if ( window.history.replaceState ) {
    window.history.replaceState( null, null, window.location.href );
  }
  function onConfirm()
  {
    var btn = document.getElementById("alert-numbers");
    btn.style.display = 'none';
    var phpCall = "<?php //confirmAlerts(); ?>";
    alerts(phpCall);
  }
</script>
</head>
<body>
  <?php if(!isset($_SESSION['email'])){ ?>
    <nav class="navbar navbar-expand-lg">
      <a class="navbar-brand" href="index.php"><h1 style="margin-right: 10px"><img src="icon/tuebook.ico" style="border:0"/> Tuebook</h1></a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
    </nav>
  <?php } else { ?>
    <?php
    $current_user = getCurrentUser();
    ?>
    <nav class="navbar navbar-expand-lg navbar-dark">
      <a class="navbar-brand" href="index.php"><h1 style="margin-right: 10px"><img src="icon/tuebook.ico" style="border:0"/> Tuebook</h1></a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <div class="form-group" style="margin-bottom:-25px; width: 250px;margin-right: 30px">
          <form action="find-result.php" method="GET" style="margin-bottom: 30px">
            <table>
              <tbody>
                <tr>
                  <td><input type="text" name="info" class="form-control" placeholder="Search here" style="width:210px"></td>
                  <td><button type="submit" name="find-submit" class="btn btn-success" style="width: 45px; height: 38px; margin-left:-3px;"><img src="icon/search.ico" style="border:0"/></button></td>
                </tbody>
              </table>
            </form>
          </div>
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <a class="nav-link" href="index.php"><h4><img src="icon/news.ico" style="border:0;margin-left:10px"/> News</h4><span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item active">
              <a class="nav-link" href="home.php"><h4 style="margin-right: 5px"><img src="img/<?php echo $current_user['avatar'];?>" style="border:0;width: 54px; height: 48px; border-radius: 50%; margin-left: 8px; margin-right: -3px"/> Home</h4><span class="sr-only">(current)</span></a>
            </li>
            <div class="dropdown">
              <button type="button" id="dropdown-alerts" name="alerts" data-toggle="dropdown" style="background-color: #084B8A; border: 0px; margin-right: 20px" onclick="onConfirm()"><img src="icon/bell.ico" style="border:0; margin-top: 7px">
                <?php
                $alerts = getAlertNumbers($current_user['email']);
                ?>
                <?php if($alerts > 0): ?>
                  <button class="btn btn-danger" id="alert-numbers" style="width: 24px; height:24px; margin-left: -35px; margin-top:-14px;"><h6 style="margin-top: -4px; margin-left:-6px;"><?php echo $alerts; ?></h6>
                  </button>
                <?php else: ?>
                  <button class="btn btn-danger" id="alert-numbers" style="width: 24px; height:24px; margin-left: -35px; margin-top:-14px; visibility: hidden;"><h6 style="margin-top: -4px; margin-left:-6px;"><?php echo $alerts; ?></h6>
                  </button>
                <?php endif; ?>
                <h4 style="color: white; text-shadow: 2px 2px black; margin-right: 30px;">Alerts </h4><span class="sr-only">(current)</span>
              </button>
              <ul class="dropdown-menu" style="background-color: white; width: 400px">
                <?php showAlerts(); ?>
              </ul>
            </div>
            <li class="nav-item active">
              <a class="nav-link" href="message.php"><img src="icon/message.ico" style="border:0;margin-left:10px; height: 45px; margin-top: 3px;"/> 
                <?php
                $count = countUnreadMessages();
                if($count > 0)
                  echo '<button class="btn btn-danger" style="width: 24px; height:24px; margin-left: -10px; margin-top:-20px;"><h6 style="margin-top: -4px; margin-left:-10px">'.$count.'</h6></button>';

                ?><h4 style="margin-left: 8px; margin-right: 35px">SMS</h4 style="margin-right:-20px"><span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item active">
                <a class="nav-link" href="friend.php"><h4><img src="icon/friend.ico" style="border:0;margin-left:10px; margin-right: -5px"/>
                  <?php
                  $count = countInvitations();
                  if($count > 99)
                    $count = 99;
                  if($count > 0)
                    echo '<button class="btn btn-danger" style="width: 24px; height:24px; margin-left: -10px; margin-top:-20px; margin-right: -8px"><h6 style="margin-top: -4px; margin-left:-6px;">'.$count.'</h6></button>';
                  ?>Friends </h4><span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                  <a class="nav-link" href="account.php"><h4><img src="icon/profile.ico" style="border:0;margin-left:10px"/> Account </h4><span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                  <a class="nav-link" href="logout.php"><h4><img src="icon/logout.ico" style="border:0; margin-left:12px"/> Logout </h4><span class="sr-only">(current)</span></a>
                </li>
              </ul>
            </div>
          </nav>
        <?php } ?>
      </body>
      </html>