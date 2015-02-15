#pragma once
#include <string>

int hashFuction(std::string text, int startIndex, int endIndex);

int circleHash(int previousHash, std::string text, int startIndex, int endIndex);