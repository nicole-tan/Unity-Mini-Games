<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>React Tutorial</title>
    <!-- Not present in the tutorial. Just for basic styling. -->
    <link rel="stylesheet" href="css/base.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/react/0.14.0/react.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/react/0.14.0/react-dom.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/babel-core/5.6.15/browser.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/marked/0.3.2/marked.min.js"></script>
  </head>
  <body>
    <div id = "navBar">
      <p> Source and Sort </p>
    </div> -->
    <form name= "url" action= "index.php" method= "POST"> 
      Please enter a URL here: <br>
      <input type="url" name = "url" id = "url">
      <input type="submit" name = "submit" value= "Submit">
      <br>
    </form> 

    <?php 
      if (isset($_POST['submit'])) {
      $pageurl = $_POST['url'];
      }

      $pagerequest = file_get_contents($pageurl);
      $pagevar = htmlentities($pagerequest);
      $pieces = explode("&gt;", $pagevar);
      //echo $pieces[2]; 
      print_r($pieces);


  /**  function pretty($arr, $level=0){
      $tabs = "";
      for($i=0;$i<$level; $i++){
          $tabs .= "    ";
      }
      foreach($arr as $key=>$val){
          if( is_array($val) ) {
              print ($tabs . $key . " : " . "\n");
              pretty($val, $level + 1);
          } else {
              if($val && $val !== 0){
                  print ($tabs . $key . " : " . $val . "\n"); 
              }
          }
      }
  }
        // Example:
        $item["A"] = array("a", "b", "c");
        $item["B"] = array("a", "b", "c");
        $item["C"] = array("a", "b", "c");

        pretty($item);

        // -------------
        // yields
        // -------------
        // A : 
        //     0 : a
        //     1 : b
        //     2 : c
        // B : 
        //     0 : a
        //     1 : b
        //     2 : c
        // C : 
        //     0 : a
        //     1 : b
        //     2 : c **/
    ?>
    <div id="content"></div>
    <script type = "text/babel" src = "scripts/htmlparser.js"> </script>
    <script type="text/babel"> </script>
  </body>
</html>
