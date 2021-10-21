#include <iostream>
using namespace std;

int main() 
{
    string s;
    long int n,count=0;
    bool least_length=false,digit=false,low_char=false,up_char=false,sp_char=false;
    cin>>n;
    cin>>s;
    if(s.length()>=6)
    {
        least_length=true;
    }
    string:: iterator it;
    for(it = s.begin();it!=s.end();it++)
    {
        if(isdigit(*it))
        {
            digit=true;
        }
        if(isupper(*it))
        {
            up_char=true;
        }
        if(islower(*it))
        {
            low_char=true;
        }
        if(isupper(*it))
        {
            up_char=true;
        }
        if(*it=='!' || *it=='@' || *it=='#' || *it=='$' || *it=='%' || *it=='^' || *it=='&' || *it=='*' || *it=='(' || *it==')' || *it=='-' || *it=='+')
        {
            sp_char=true;
        }
    }
    if(digit==false) count++; 
    if(low_char==false) count++;
    if(up_char==false) count++;
    if(sp_char==false) count++;

    if(least_length==false)
    {
        if(count<=(6-s.length())) 
            cout<<(6-s.length());
        else 
            cout<<count;
    }
    else
    {
        cout<<count;
    }
    return 0;
}
