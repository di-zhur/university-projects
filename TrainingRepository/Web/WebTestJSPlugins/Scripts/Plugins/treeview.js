
var TreeView = (function () {
    
    var _data = [
        {
            name: "Root",
            children: [
                {
                    name: "Item1",
                    children:
                    [
                        {
                            name: "Item1.1",
                            children:
                            [
                                {
                                    name: "Item1.1.1",
                                },
                                {
                                    name: "Item1.1.2",
                                }
                            ]
                        },
                        {
                            name: "Item1.2"
                        }
                    ]
                },
                {
                    name: "Item2",
                    children:
                    [
                        {
                            name: "Item2.1"
                        }
                    ]
                },
                {
                    name: "Item3"
                }
            ]
        }
    ];

    var _default = {};

    var _events = {};

    function TreeView() {

    }

    TreeView.prototype.create = function () {
        var divTree = document.getElementById('tree');
        divTree.onclick = treeEvent;
        drawNode(divTree, _data);
    }

    function drawNode(parentNode, values) {
        var ul = createElement('ul', parentNode);
        ul.setAttribute("expand", "true");
        for (var i in values) {
            var node = values[i];
            var li = createElement('li', ul);
            li.id = node.name;
            li.innerHTML = node.name;
            if (node.hasOwnProperty('children')) {
                drawNode(li, node.children);
            }
        }
    }

    function treeEvent(e) {
        var element = e.target;
        var childNodes = element.childNodes;

        for (var i = 0; i < childNodes.length; i++){
            var childNode = childNodes[i];
            if (childNode.nodeName.toLowerCase() === 'ul') {
                var attrs = childNode.attributes;

                for (var j = 0; j < attrs.length; j++){
                    var attr = attrs[j];
                    if (attr.nodeName === 'expand') {
                        var expand = attr.value;
                        if (expand === 'true') {
                            attr.value = 'false';
                            $(childNode).hide();
                        } else if (expand === 'false') {
                            attr.value = 'true';
                            $(childNode).show();
                        }
                    }
                }
            }
        }
    }

    function createElement(el, parentNode) {
        var elem = document.createElement(el);
        parentNode.appendChild(elem);
        return elem;
    }
    
    return TreeView;
}());


        //divTree.onclick = function (e) {
        //    var nodeValue = e.currentTarget.attributes['obj'].nodeValue;
        //    var valueObj = JSON.parse(nodeValue);
        //    alert(valueObj.name);
        //};
