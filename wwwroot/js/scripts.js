var routes_list = [{namber: 1, done: false},
				{namber: 2, done: true},
				{namber: 3, done: false},
				{namber: 4, done: false},
				{namber: 5, done: false},];
			function onchange (e) {
				var checkbox = this;
				checkbox.route.done = checkbox.checked;
				
				
			}
			function checkboxer(list) {
				list.forEach(function(route, list) {
					var box = document.getElementById('select_routes');
					var li = document.createElement('li');
					var num = document.createTextNode((route.namber)+"."); 
					 
					var checkbox = document.createElement('input');
					li.appendChild(num);
					li.appendChild(checkbox);
					checkbox.setAttribute("type", "checkbox");
					checkbox.setAttribute("name", "route"+route.namber);
					checkbox.setAttribute("id", "route"+route.namber);
					if (route.done) {
						checkbox.setAttribute("checked", "checked");
					}
					box.appendChild(li);
					checkbox.route = route;
					checkbox.onchange = onchange;
					
				});
						
				}
