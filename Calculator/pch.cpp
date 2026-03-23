// pch.cpp: source file corresponding to the pre-compiled header

#include "pch.h"

// When you are using pre-compiled headers, this source file is necessary for compilation to succeed.
#include "Calculator.h"
#define MYLIB_EXPORTS

Calculator* CreateCalculatorObject() {
	return new Calculator();
}

void DeleteCalculatorObject(Calculator* obj) {
	delete obj;
}

int Add(Calculator* obj, int a, int b) {
	if (obj != nullptr) {
		return obj->Add(a, b);
	}
	throw "object is nullptr";
}

