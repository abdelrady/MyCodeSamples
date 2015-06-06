#include <iostream>
//#include <cstdlib>          //for srand(), rand()
//#include <ctime>            //for time for srand()
using namespace std;


class FullQueue
{};
class EmptyQueue
{};

typedef int ItemType;
class QueType
{
public:
  QueType(int max);
  QueType();
  ~QueType();
  void MakeEmpty();
  bool IsEmpty() const;
  bool IsFull() const;
  void Enqueue(ItemType newItem,double arriveTime);
  void Dequeue(ItemType& item);
  double calc();
private:
  int front;
  int rear;
  ItemType* items;
  double* arTime;
  int maxQue;

  int waitTime;
};

void main2(int argv[],char** argc)
{
	srand(1 /*time(NULL)*/ );  
	QueType qu=QueType(10002);

	int k;
	double arriveTime=0.0;
	for(int i=0;i<10000;i++)
	{
		k = rand()%10; 
		cout<<k<<" ";
		if(k>8)arriveTime=.1;
		else if(k>5)arriveTime=.5;
		else arriveTime=.9;
		qu.Enqueue(k,arriveTime);
	}
	cout<<"Average Waiting Time Is:"<<qu.calc()/10000.0<<endl;
	 
}


QueType::QueType(int max)
// Parameterized class constructor.
// Post: maxQue, front, and rear have been initialized.
//       The array to hold the queue elements has been dynamically
//       allocated.
{
  maxQue = max + 1;
  front = maxQue - 1;
  rear = maxQue - 1;
  items = new ItemType[maxQue];
  arTime=new double[maxQue];
}
QueType::QueType()      // Default class constructor.
// Post: maxQue, front, and rear have been initialized.
//       The array to hold the queue elements has been dynamically
//       allocated.
{
  maxQue = 501;
  front = maxQue - 1;
  rear = maxQue - 1;
  items = new ItemType[maxQue];
  
}
QueType::~QueType()     // Class destructor.
{
  delete [] items;
  delete [] arTime;
}
void QueType::MakeEmpty()
// Post: front and rear have been reset to the empty state.
{
  front = maxQue - 1;
  rear = maxQue - 1;
}
bool QueType::IsEmpty() const
// Returns true if the queue is empty; false otherwise.
{
  return (rear == front);
}

bool QueType::IsFull() const
// Returns true if the queue is full; false otherwise.
{
  return ((rear + 1) % maxQue == front);
}

void QueType::Enqueue(ItemType newItem,double arriveTime)
// Post: If (queue is not full) newItem is at the rear of the queue;
//       otherwise, a FullQueue exception is thrown.
{
  if (IsFull())
    throw FullQueue();
  else
  {
    rear = (rear +1) % maxQue;
    items[rear] = newItem;
	arTime[rear] = arriveTime;

  }
}

double QueType::calc()
{

		front = (front + 1) % maxQue;
		double total=0.0,waitNext=0.0,WaitAll=0.0;
		total+=items[front];
		
	while(!IsEmpty())
	{
		waitNext=total-arTime[front];
		front = (front + 1) % maxQue;
		double total=0.0;
		total+=waitNext+items[front];
		WaitAll+=total;
	}
	return WaitAll;
}

/*void QueType::Dequeue(ItemType& item,double arivveTime)
// Post: If (queue is not empty) the front of the queue has been
//       removed and a copy returned in item;
//       otherwise, an EmptyQueue exception is thrown.
{
  if (IsEmpty())
    throw EmptyQueue();
  else
  {
    front = (front + 1) % maxQue;
    item = items[front] ;
  }
}*/
