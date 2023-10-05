class Node {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class SLL {
    constructor() {
        this.head = null;
    }

    isEmpty() {
        return this.head === null;
    }

    addToFront(value) {
        let newNode = new Node(value);
        if (this.isEmpty()) {
            this.head = newNode;
        } else {
            newNode.next = this.head;
            this.head = newNode;
        }
        return this;
    }
}

let nodeOne = new Node(10);
let nodeTwo = new Node(-2);
const sll = new SLL();
const sllTwo = new SLL();
nodeOne.next = nodeTwo;
sll.head = nodeOne;

console.log("Is the first sll empty?", sll.isEmpty());
