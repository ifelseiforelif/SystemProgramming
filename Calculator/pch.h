// pch.h: This is a precompiled header file.
// Files listed below are compiled only once, improving build performance for future builds.
// This also affects IntelliSense performance, including code completion and many code browsing features.
// However, files listed here are ALL re-compiled if any one of them is updated between builds.
// Do not add files here that you will be updating frequently as this negates the performance advantage.

#ifndef PCH_H
#define PCH_H

// add headers that you want to pre-compile here
#pragma once
#include "framework.h"
#include "Calculator.h"


#ifdef _WIN32
#ifdef MYLIB_EXPORTS
#define MYLIB_API __declspec(dllexport)
#else
#define MYLIB_API __declspec(dllimport)
#endif
#else
#define MYLIB_API
#endif

#ifdef __cplusplus
extern "C" {
#endif

    MYLIB_API Calculator* CreateCalculatorObject();
    MYLIB_API void DeleteCalculatorObject(Calculator* calc);
    MYLIB_API int Add(Calculator* calc, int a, int b);

#ifdef __cplusplus
}
#endif
#endif //PCH_H
