# SourceAFIS for .NET #

target framework net. 4.0

example:
            AfisEngine Afis = new AfisEngine();

            Fingerprint fp1 = new Fingerprint();
            fp1.AsBitmap = new Bitmap(@"G:\huellas\yo\pulgar derecho.png");

            Fingerprint fp2 = new Fingerprint();
            fp2.AsBitmap = new Bitmap("huella.png");

            Person person1 = new Person();
            person1.Fingerprints.Add(fp1);

            Person person2 = new Person();
            person2.Fingerprints.Add(fp2);

            Afis.Extract(person1);
            Afis.Extract(person2);

            float score = Afis.Verify(person1, person2);
            bool match = (score > 0);
            MessageBox.Show("res:"+match.ToString()+" "+score);


SourceAFIS is a fingerprint recognition engine that takes a pair of human fingerprint images and returns their similarity score.
It can do 1:1 comparisons as well as efficient 1:N search. This is the .NET implementation of the SourceAFIS algorithm.

Please use the last stable release tagged 1.7. All new commits are part of an incomplete upgrade.
If you are in hurry to use some newer features,
either use [SourceAFIS for Java](https://sourceafis.machinezoo.com/java)
or consider [sponsoring](https://sourceafis.machinezoo.com/custom) development of the .NET implementation.

* Documentation: [.NET Tutorial](https://sourceafis.machinezoo.com/net), [.NET API Reference](https://sourceafis.machinezoo.com/documentation/html/N_SourceAFIS_Simple.htm), [Algorithm](https://sourceafis.machinezoo.com/algorithm), [SourceAFIS Overview](https://sourceafis.machinezoo.com/)
* Download: see [.NET Tutorial](https://sourceafis.machinezoo.com/net)
* Sources: [GitHub](https://github.com/robertvazan/sourceafis-net), [Bitbucket](https://bitbucket.org/robertvazan/sourceafis-net)
* Issues: [GitHub](https://github.com/robertvazan/sourceafis-net/issues), [Bitbucket](https://bitbucket.org/robertvazan/sourceafis-net/issues)
* License: [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0)

