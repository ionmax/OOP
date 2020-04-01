#include <iostream>
#include "Segment.h"
#include "Points.h"

using namespace std;

int main()
{
	Segment *mySegment = new Segment(4, 5, 12, 15);

	cout << "Begin:(" << mySegment->GetX(Begin) << ";" << mySegment->GetY(Begin) << ")" <<
		"End:(" << mySegment->GetX(End) << ";" << mySegment->GetY(End) << ")" << endl;
	cout << mySegment->Length() << endl;

	mySegment->Reduction(5);

	cout << "Begin:(" << mySegment->GetX(Begin) << ";" << mySegment->GetY(Begin) << ")" <<
		"End:(" << mySegment->GetX(End) << ";" << mySegment->GetY(End) << ")" << endl;
	cout << mySegment->Length();

	char n;
	cin >> n;
	return 0;
};
