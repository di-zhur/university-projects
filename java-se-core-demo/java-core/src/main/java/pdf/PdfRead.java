package pdf;

import java.util.*;

public class PdfRead {

    private static final String FILE__NAME = "/tmp/itext.pdf";

    public static void main(String[] args) {
        Node root = new Node(1);
        root.children = List.of(new Node(3, List.of(new Node(5), new Node(6))), new Node(2), new Node(4));
        List<List<Integer>> vals = new ArrayList<>();
        List<Integer> rootVal = new ArrayList<>();
        rootVal.add(root.val);
        vals.add(rootVal);

        Queue<Node> nodeQueue = new ArrayDeque<>();
        nodeQueue.add(root);
        while (!nodeQueue.isEmpty()) {
            root = nodeQueue.poll();
            if (root.children != null) {
                List<Integer> subVals = new LinkedList<>();
                for (int i = 0; i < root.children.size(); i++) {
                    Node node = root.children.get(i);
                    if (node != null) {
                        nodeQueue.add(node);
                        subVals.add(node.val);
                    }
                }
                if (!subVals.isEmpty()) {
                    vals.add(subVals);
                }
            }
        }
        System.out.println(vals);
    }

    public List<Integer> preorder(Node node) {
        List<Integer> vals = new ArrayList<>();
        Stack<Node> stack = new Stack<>();
        stack.push(node);
        while (stack.isEmpty()) {
            Node node1 = stack.pop();
            vals.add(node1.val);
            for (Node node2 : node1.children) {
                if (node2 != null) {
                    stack.push(node2);
                }
            }
        }
        return vals;
    }

    public static class Node {
        public int val;
        public List<Node> children;

        public Node() {
        }

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, List<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    ;

}
