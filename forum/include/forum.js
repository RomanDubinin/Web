var selPost;

function showPost(_post, _auth, _date, _id, topic, _type, _tid, _level)
{
	var post = document.getElementById(_post);
	var auth = document.getElementById(_auth);
	var date = document.getElementById(_date);
	var type = document.getElementById(_type);
	var id = document.getElementById(_id);
	var tid = document.getElementById(_tid);
	var level = document.getElementById(_level);
	window.scrollBy(0, document.getElementById("PostPlace").offsetTop);
		
	document.getElementById("PostPlace").src = "PostBody.aspx?id=" + id.innerHTML;
	
	document.getElementById("PostAuthor").innerHTML = "<strong>Автор:</strong> " + auth.innerHTML;	
	document.getElementById("PostDate").innerHTML = "<strong>Дата:</strong> " + date.innerHTML;	
	document.getElementById("PostTopic").innerHTML = "<strong>Тема:</strong> " + topic.innerHTML;	
	document.getElementById("HiddenID").value = id.innerHTML;
	document.getElementById("HiddenTID").value = tid.innerHTML;
	document.getElementById("HiddenTopic").value = topic.innerHTML;
	document.getElementById("HiddenLevel").value = level.innerHTML;
	document.getElementById("Answer").style.display = "inline";

	if (type.innerHTML != "normal")
		document.getElementById("Answer").style.display = "none";
	
	if (selPost != null)
		selPost.className = "TreeRoot";
	
	topic.className = "SelectedPost";
	selPost = topic;
}

function overPost(item)
{
	if (item.className != "SelectedPost")
		item.className = "TreeHover";
}

function outPost(item)
{
	if (item.className != "SelectedPost")
		item.className = "TreeRoot";
}

function reply()
{
	answer = document.getElementById("HiddenID").value;
	topicID = document.getElementById("HiddenTID").value;
	level = document.getElementById("HiddenLevel").value;

	performPost(level, topicID, answer);
}

function newPost()
{
	performPost(0, -1, -1);
}


function performPost(level, topicID, answer)
{
	forum = document.getElementById("IDBox").value;
	topic = document.getElementById("HiddenTopic").value;	
	query = "post.aspx?ID=" + forum + "&answer=" + answer +
		"&topic=" + topic + "&topicID=" + topicID + "&level=" + level;
			
	window.open(query, 
		null, "height=378,width=438,status=no,resizable=no;fullscreen=no;toolbar=no,menubar=no,location=no");
}

function TreeExpand (item, img) 
{
	if (item.style.display == "block") 
	{
		item.style.visibility = "hidden";
		item.style.display = "none";		
		img.src = "clip\\tplus.gif";		
	}
	else
	{		
		item.style.display = "block";		
		item.style.visibility = "visible";
		img.src = "clip\\tminus.gif";
	}		
}

function goNext()
{
	var cp = (document.getElementById("CountBox").value - 0);
			
	if (cp == "")
		document.getElementById("CountBox").value = 1;
	else
	{
		cp = cp + 1;
		document.getElementById("CountBox").value = cp;
	}					
	
	pasteGeneral();			
}

function goPrevious()
{
	var cp = (document.getElementById("CountBox").value - 0); 
	cp = cp - 1;
	document.getElementById("CountBox").value = cp;
	pasteGeneral();
}

function pasteGeneral()
{
	document.getElementById('IDBox').value = 'forumname';
}

function refresh()
{
	document.getElementById("PerPageBox").value = 
		document.getElementById("PerPage").value;
}