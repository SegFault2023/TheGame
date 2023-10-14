// Copyright Epic Games, Inc. All Rights Reserved.

#include "TheGameGameMode.h"
#include "TheGameCharacter.h"
#include "UObject/ConstructorHelpers.h"

ATheGameGameMode::ATheGameGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPerson/Blueprints/BP_ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
