#include "stdafx.h"

HOOKPROC wrappedHooks[16];

LRESULT WINAPI wrapper00(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 0])(code, wparam, lparam);}
LRESULT WINAPI wrapper01(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 1])(code, wparam, lparam);}
LRESULT WINAPI wrapper02(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 2])(code, wparam, lparam);}
LRESULT WINAPI wrapper03(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 3])(code, wparam, lparam);}
LRESULT WINAPI wrapper04(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 4])(code, wparam, lparam);}
LRESULT WINAPI wrapper05(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 5])(code, wparam, lparam);}
LRESULT WINAPI wrapper06(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 6])(code, wparam, lparam);}
LRESULT WINAPI wrapper07(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 7])(code, wparam, lparam);}
LRESULT WINAPI wrapper08(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 8])(code, wparam, lparam);}
LRESULT WINAPI wrapper09(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[ 9])(code, wparam, lparam);}
LRESULT WINAPI wrapper10(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[10])(code, wparam, lparam);}
LRESULT WINAPI wrapper11(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[11])(code, wparam, lparam);}
LRESULT WINAPI wrapper12(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[12])(code, wparam, lparam);}
LRESULT WINAPI wrapper13(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[13])(code, wparam, lparam);}
LRESULT WINAPI wrapper14(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[14])(code, wparam, lparam);}
LRESULT WINAPI wrapper15(int code, WPARAM wparam, LPARAM lparam) { return (wrappedHooks[15])(code, wparam, lparam);}


const HOOKPROC wrappers[] = {
	wrapper00, wrapper01, wrapper02, wrapper03,
	wrapper04, wrapper05, wrapper06, wrapper07,
	wrapper08, wrapper09, wrapper10, wrapper11,
	wrapper12, wrapper13, wrapper14, wrapper15
};

BOOL APIENTRY DllMain( HMODULE hModule,
					  DWORD  fdwReason,
					  LPVOID lpReserved
					  )
{
	if (fdwReason == DLL_PROCESS_ATTACH) {
		for(int i=0; i<16; i++) {
			wrappedHooks[i] = NULL;
		}
	}
	return TRUE;
}

extern "C"
__declspec(dllexport)
HOOKPROC WINAPI AllocHookWrapper(HOOKPROC wrapped) {
	for(int i=0; i<16; i++) {
		if (wrappedHooks[i] == NULL) {
			wrappedHooks[i] = wrapped;
			return wrappers[i];
		}
	}
	return NULL;
}

extern "C"
__declspec(dllexport)
BOOL WINAPI FreeHookWrapper(HOOKPROC wrapper) {
	for(int i=0; i<16; i++) {
		if (wrappers[i] == wrapper) {
			wrappedHooks[i] = NULL;
			return TRUE;
		}
	}
	return FALSE;
}
