using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaesarCipher {
    //Julius Caesar protected his confidential information by encrypting it using a cipher. Caesar's cipher shifts each letter by a number of
    //letters. If the shift takes you past the end of the alphabet, just rotate back to the front of the alphabet. In the case of a rotation by 3,
    //w, x, y and z would map to z, a, b and c.

    //    Original alphabet:      abcdefghijklmnopqrstuvwxyz
    //    Alphabet rotated +3:    defghijklmnopqrstuvwxyzabc

    //Example
    //s = There's-a-starman-waiting-in-the-sky
    //k = 3
    //The alphabet is rotated by 3, matching the mapping above. The encrypted string is "Wkhuh'v-d-vwdupdq-zdlwlqj-lq-wkh-vnb".
    //Note: The cipher only encrypts letters; symbols, such as -, remain unencrypted.    

//Sample Input
//middle-Outz
//2

//Sample Output
//okffng-Qwvb

//Explanation
//Original alphabet:      abcdefghijklmnopqrstuvwxyz
//Alphabet rotated +2:    cdefghijklmnopqrstuvwxyzab

//m -> o
//i -> k
//d -> f
//d -> f
//l -> n
//e -> g
//-    -
//O -> Q
//u -> w
//t -> v
//z -> b

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(caesarCipher("There's-a-starman-waiting-in-the-sky", 3));//Expected: Wkhuh'v-d-vwdupdq-zdlwlqj-lq-wkh-vnb
            Console.WriteLine(caesarCipher("middle-Outz", 2));//Expected: okffng-Qwvb
            Console.WriteLine(caesarCipher("Always-Look-on-the-Bright-Side-of-Life", 5));//Expected: Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj
            Console.WriteLine(caesarCipher("www.abc.xy", 87));//Expected: fff.jkl.gh
            Console.WriteLine(
                caesarCipher("!m-rB`-oN!.W`cLAcVbN/CqSoolII!SImji.!w/`Xu`uZa1TWPRq`uRBtok`xPT`lL-zPTc.BSRIhu..-!.!tcl!-U", 62)
                );//!w-bL`-yX!.G`mVKmFlX/MaCyyvSS!CSwts.!g/`He`eJk1DGZBa`eBLdyu`hZD`vV-jZDm.LCBSre..-!.!dmv!-E
        }

        public static string caesarCipher(string s, int k) {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] rotated = new char[s.Length]; //List<char> rotated = new List<char>();

            for (int i = 0; i < s.Length; i++) {

                if (!char.IsLetter(s[i])) {
                    rotated[i] = s[i]; //rotated.Add(s[i]);
                    continue;
                }

                int index = alphabet.IndexOf(char.ToLower(s[i])); // int index = Array.IndexOf(charArray, letter);                  
                index = (index + k) % alphabet.Length; //Using modulus index will never go past alphabet.Length (26)      
                char cipherLetter = alphabet[index];
                rotated[i] = char.IsUpper(s[i]) ? char.ToUpper(cipherLetter) : cipherLetter; //rotated.Add(char.IsUpper(s[i]) ? char.ToUpper(cipherLetter) : cipherLetter);
            }

            return string.Join("", rotated); //return new string(rotated.ToArray());                               
        }

        public static string caesarCipher2(string s, int k) {
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            IEnumerable<char> last = new char[] { };

            if (alpha.Length < k) {
                k = k % alpha.Length;
                last = alpha.Take(k);
            } else {
                last = alpha.Take(k);
            }

            List<char> rotated = new List<char>();
            Dictionary<char, char> hash = new Dictionary<char, char>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < alpha.Length - k; i++) {
                rotated.Add(alpha[i + k]);
            }

            foreach (var item in last) {
                rotated.Add(item);
            }

            for (int i = 0; i < alpha.Length; i++) {
                hash.Add(alpha[i], rotated[i]);
            }

            for (int i = 0; i < s.Length; i++) {

                if (!char.IsLetter(s[i])) {
                    sb.Append(s[i]);
                    continue;
                }                

                if (char.IsUpper(s[i])) {
                    char lower = Char.ToLower(s[i]);

                    if (hash.ContainsKey(lower)) {
                        char upper = Char.ToUpper(hash[lower]);
                        sb.Append(upper);
                    } else {
                            sb.Append(s[i]);
                    }

                } else {
                    if (hash.ContainsKey(s[i])) {
                        sb.Append(hash[s[i]]);

                    } else {
                        sb.Append(s[i]);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
