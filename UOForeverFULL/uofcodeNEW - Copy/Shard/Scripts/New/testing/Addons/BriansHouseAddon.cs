
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class brianshouseAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {19249, -15, -14, 0}, {19196, -15, -15, 20}, {19200, -20, -14, 40}// 1	2	3	
			, {19260, -14, -11, 20}, {19260, -13, -11, 20}, {19196, -15, -13, 20}// 4	5	6	
			, {19246, -12, -17, 20}, {19260, -18, -17, 40}, {19249, -15, -10, 20}// 7	8	9	
			, {19200, -20, -13, 40}, {19198, -15, -11, 0}, {19200, -20, -12, 40}// 10	11	12	
			, {19260, -19, -17, 40}, {19260, -12, -17, 40}, {19244, -11, -11, 25}// 13	14	15	
			, {19260, -14, -17, 40}, {19246, -13, -17, 20}, {19249, -15, -10, 0}// 16	17	18	
			, {19196, -15, -16, 20}, {19200, -11, -10, 20}, {19246, -14, -17, 20}// 19	20	21	
			, {19260, -15, -17, 40}, {19200, -20, -10, 40}, {19246, -11, -17, 20}// 22	23	24	
			, {19260, -11, -17, 40}, {19246, -14, -17, 0}, {19246, -12, -17, 0}// 25	26	27	
			, {19198, -15, -15, 0}, {19196, -15, -11, 20}, {19930, -13, -17, 0}// 28	29	30	
			, {19246, -13, -17, 0}, {19260, -12, -11, 20}, {19249, -15, -12, 0}// 31	32	33	
			, {19244, -15, -17, 20}, {19255, -20, -17, 40}, {19260, -11, -11, 20}// 34	35	36	
			, {19275, -14, -12, 10}, {19200, -20, -11, 40}, {19196, -15, -16, 0}// 37	38	39	
			, {19200, -20, -16, 40}, {19198, -15, -13, 0}, {19246, -11, -17, 0}// 40	41	42	
			, {19260, -17, -17, 40}, {19196, -15, -14, 20}, {19244, -15, -17, 0}// 43	44	45	
			, {19196, -15, -10, 20}, {19128, -14, -16, 40}, {19196, -15, -12, 20}// 46	47	48	
			, {19260, -13, -17, 40}, {19260, -16, -17, 40}, {19200, -20, -15, 40}// 49	50	51	
			, {19273, -14, -16, 0}, {18325, -14, -13, 0}, {19200, -20, 2, 40}// 52	53	54	
			, {19192, -11, 5, 0}, {19215, -15, -3, 0}, {19244, -20, 5, 0}// 55	56	57	
			, {19246, -17, 5, 20}, {19196, -15, -2, 20}, {19248, -15, 5, 0}// 58	59	60	
			, {19244, -12, 6, 0}, {19260, -11, -1, 20}, {19260, -12, -1, 20}// 61	62	63	
			, {19200, -11, -9, 20}, {19260, -14, -1, 20}, {19200, -11, -6, 20}// 64	65	66	
			, {19249, -15, 1, 0}, {19246, -15, 5, 20}, {19246, -19, 5, 0}// 67	68	69	
			, {19227, -15, -6, 0}, {19249, -15, 3, 0}, {19198, -15, -2, 0}// 70	71	72	
			, {19215, -15, 4, 0}, {19225, -15, -4, 0}, {19200, -11, -8, 20}// 73	74	75	
			, {19244, -20, 5, 20}, {18053, -12, 1, 0}, {19248, -12, 5, 0}// 76	77	78	
			, {19200, -11, -2, 20}, {19196, -20, 6, 20}, {19215, -15, 4, 20}// 79	80	81	
			, {19226, -15, -5, 0}, {19223, -15, -5, 20}, {19196, -20, 6, 20}// 82	83	84	
			, {19200, -11, -1, 20}, {19200, -11, -3, 20}, {19200, -20, 1, 40}// 85	86	87	
			, {19200, -20, 6, 40}, {19246, -16, 5, 20}, {19246, -19, 5, 20}// 88	89	90	
			, {19198, -15, 2, 0}, {19200, -11, -7, 20}, {19244, -11, -1, 25}// 91	92	93	
			, {19196, -15, -9, 20}, {19215, -15, -7, 20}, {19196, -15, 0, 20}// 94	95	96	
			, {19224, -15, -6, 20}, {19215, -15, -7, 0}, {19200, -20, 0, 40}// 97	98	99	
			, {19200, -20, -2, 40}, {19200, -11, -5, 20}, {19196, -15, -1, 20}// 100	101	102	
			, {19195, -15, 4, 20}, {19196, -15, 3, 20}, {19196, -15, 2, 20}// 103	104	105	
			, {19222, -15, -4, 20}, {19200, -20, -4, 40}, {19200, -20, -5, 40}// 106	107	108	
			, {19200, -20, -6, 40}, {19200, -20, -7, 40}, {19200, -20, -8, 40}// 109	110	111	
			, {19200, -20, -9, 40}, {19260, -11, 5, 20}, {19192, -13, 5, 0}// 112	113	114	
			, {19196, -20, 6, 0}, {19260, -13, -1, 20}, {19196, -12, 6, 20}// 115	116	117	
			, {19200, -20, 4, 40}, {19200, -20, 5, 40}, {19198, -15, -9, 0}// 118	119	120	
			, {19192, -18, 5, 0}, {19200, -20, -3, 40}, {19248, -17, 5, 0}// 121	122	123	
			, {19246, -18, 5, 20}, {19200, -20, -1, 40}, {19192, -16, 5, 0}// 124	125	126	
			, {19246, -14, 5, 0}, {19198, -15, 0, 0}, {19249, -15, -8, 0}// 127	128	129	
			, {19200, -20, 3, 40}, {19215, -15, -3, 20}, {19249, -15, -1, 0}// 130	131	132	
			, {19196, -15, 1, 20}, {19196, -15, -8, 20}, {19200, -11, -4, 20}// 133	134	135	
			, {18137, -14, -5, 0}, {18323, -14, 2, 0}, {19201, -11, 14, 15}// 136	137	138	
			, {19196, -20, 11, 0}, {19196, -20, 10, 0}, {19246, -19, 16, 0}// 139	140	141	
			, {19248, -17, 16, 0}, {19260, -19, 16, 40}, {19196, -20, 13, 20}// 142	143	144	
			, {19244, -12, 9, 0}, {18224, -16, 14, 40}, {19246, -12, 16, 0}// 145	146	147	
			, {19207, -11, 12, 0}, {19260, -18, 16, 40}, {19245, -20, 16, 0}// 148	149	150	
			, {19200, -20, 8, 40}, {19200, -20, 7, 40}, {19207, -11, 13, 5}// 151	152	153	
			, {18055, -19, 13, 0}, {19192, -18, 16, 0}, {19196, -20, 8, 20}// 154	155	156	
			, {19196, -20, 12, 0}, {19196, -20, 13, 0}, {19196, -20, 14, 20}// 157	158	159	
			, {19192, -14, 16, 20}, {19260, -11, 12, 40}, {19196, -20, 11, 20}// 160	161	162	
			, {19215, -12, 12, 0}, {19196, -12, 11, 20}, {19215, -12, 14, 0}// 163	164	165	
			, {19210, -12, 12, 40}, {19205, -11, 17, 0}, {18325, -11, 10, 0}// 166	167	168	
			, {19215, -12, 13, 0}, {19196, -12, 7, 20}, {19196, -20, 9, 0}// 169	170	171	
			, {19192, -14, 16, 0}, {19248, -15, 16, 20}, {19192, -16, 16, 20}// 172	173	174	
			, {19260, -15, 16, 40}, {19260, -14, 16, 40}, {19260, -13, 16, 40}// 175	176	177	
			, {18731, -15, 13, 40}, {18055, -19, 7, 0}, {19215, -12, 15, 0}// 178	179	180	
			, {18229, -16, 15, 40}, {19205, -11, 16, 5}, {19207, -11, 14, 10}// 181	182	183	
			, {19207, -11, 12, 5}, {19196, -20, 7, 20}, {19192, -16, 16, 0}// 184	185	186	
			, {19196, -20, 15, 20}, {19246, -11, 12, 20}, {18730, -15, 13, 40}// 187	188	189	
			, {19248, -13, 16, 0}, {19248, -15, 16, 0}, {19246, -19, 16, 20}// 190	191	192	
			, {19246, -12, 16, 20}, {18220, -17, 13, 40}, {19204, -11, 13, 15}// 193	194	195	
			, {19246, -11, 12, 15}, {19196, -20, 8, 0}, {19207, -11, 14, 5}// 196	197	198	
			, {19200, -12, 14, 40}, {19200, -12, 13, 40}, {19196, -12, 10, 20}// 199	200	201	
			, {19202, -12, 17, 0}, {19200, -12, 15, 40}, {18705, -19, 11, 0}// 202	203	204	
			, {19205, -11, 15, 10}, {19196, -20, 9, 20}, {19200, -20, 16, 40}// 205	206	207	
			, {19200, -20, 15, 40}, {19200, -20, 14, 40}, {19200, -20, 13, 40}// 208	209	210	
			, {19200, -20, 12, 40}, {19200, -20, 11, 40}, {18704, -18, 9, 7}// 211	212	213	
			, {19207, -11, 15, 5}, {19248, -13, 16, 20}, {19207, -11, 14, 0}// 214	215	216	
			, {19207, -11, 13, 0}, {18233, -16, 13, 40}, {19196, -12, 8, 20}// 217	218	219	
			, {19196, -20, 12, 20}, {19200, -20, 10, 40}, {19192, -18, 16, 20}// 220	221	222	
			, {19196, -20, 14, 0}, {19208, -12, 16, 40}, {19196, -12, 16, 20}// 223	224	225	
			, {19196, -20, 10, 20}, {19248, -17, 16, 20}, {19200, -20, 9, 40}// 226	227	228	
			, {19260, -17, 16, 40}, {19207, -11, 13, 10}, {19207, -11, 15, 0}// 229	230	231	
			, {19196, -12, 9, 20}, {19196, -20, 14, 20}, {19244, -20, 16, 20}// 232	233	234	
			, {19260, -16, 16, 40}, {19207, -11, 16, 0}, {19207, -11, 12, 10}// 235	236	237	
			, {18230, -17, 15, 40}, {18219, -16, 13, 40}, {18225, -17, 14, 40}// 238	239	240	
			, {18228, -15, 14, 40}, {19196, -20, 15, 0}, {19196, -20, 7, 0}// 241	242	243	
			, {18325, -15, 17, 0}, {19246, 2, -17, 0}, {19260, -1, -17, 40}// 244	245	246	
			, {19109, 4, -16, 40}, {19260, -10, -17, 40}, {19246, -5, -17, 0}// 247	248	249	
			, {19218, 0, -17, 20}, {19246, 3, -17, 20}, {19237, 3, -11, 40}// 250	251	252	
			, {18648, -8, -10, 40}, {18644, 0, -10, 40}, {19246, 5, -17, 20}// 253	254	255	
			, {19242, 0, -11, 40}, {19260, -9, -17, 40}, {19221, 0, -17, 0}// 256	257	258	
			, {19188, -2, -15, 40}, {19272, 3, -16, 40}, {19246, -4, -17, 20}// 259	260	261	
			, {19240, -2, -12, 40}, {18149, -1, -16, 0}, {19246, 1, -17, 0}// 262	263	265	
			, {19246, 5, -17, 0}, {19246, -7, -17, 0}, {19236, 2, -10, 40}// 266	267	268	
			, {19094, 1, -12, 45}, {18855, 3, -16, 40}, {19246, -4, -17, 0}// 269	270	271	
			, {19219, -2, -17, 0}, {19108, 2, -16, 40}, {19235, 3, -12, 40}// 272	273	274	
			, {19216, -2, -17, 20}, {18851, 1, -16, 40}, {19237, -2, -10, 40}// 275	276	277	
			, {19242, 1, -11, 40}, {19200, -9, -16, 20}, {19273, 2, -16, 40}// 278	279	280	
			, {19241, -2, -11, 40}, {19090, 1, -16, 8}, {19260, 5, -17, 40}// 281	282	283	
			, {19260, -4, -17, 40}, {19240, -1, -12, 40}, {19260, -2, -17, 40}// 284	285	286	
			, {19246, -3, -17, 0}, {19246, 1, -17, 20}, {19260, -6, -17, 40}// 287	288	289	
			, {19246, 4, -17, 0}, {19246, -9, -17, 0}, {18814, -1, -12, 45}// 290	291	292	
			, {19242, -1, -11, 40}, {19246, -5, -17, 20}, {19234, -3, -12, 40}// 293	294	295	
			, {19260, 1, -17, 40}, {18166, -9, -16, 40}, {19246, -8, -17, 20}// 296	297	298	
			, {18713, -3, -12, 45}, {18849, -5, -16, 40}, {18856, 2, -16, 40}// 299	300	301	
			, {19236, -3, -10, 40}, {18172, 3, -12, 45}, {19237, 3, -10, 40}// 302	303	304	
			, {19260, -8, -17, 40}, {19246, 2, -17, 20}, {19246, -10, -17, 0}// 306	307	308	
			, {19236, -3, -11, 40}, {19246, 3, -17, 0}, {19200, -9, -14, 20}// 309	310	311	
			, {19246, -9, -17, 20}, {18323, -8, -12, 21}, {18635, -2, -11, 45}// 312	313	314	
			, {19260, -7, -17, 40}, {19097, -7, -16, 40}, {19260, 0, -17, 40}// 315	316	317	
			, {19217, -1, -17, 20}, {19260, 2, -17, 40}, {19260, -8, -13, 20}// 318	319	320	
			, {19260, -7, -13, 20}, {19260, -6, -13, 20}, {19260, -5, -13, 20}// 321	322	323	
			, {19260, -4, -13, 20}, {19260, -3, -13, 20}, {19260, -2, -13, 20}// 324	325	326	
			, {19260, -1, -13, 20}, {19260, 0, -13, 20}, {19260, 1, -13, 20}// 327	328	329	
			, {19260, 2, -13, 20}, {19260, 3, -13, 20}, {19260, 4, -13, 20}// 330	331	332	
			, {19260, 5, -13, 20}, {19260, -3, -17, 40}, {19260, 3, -17, 40}// 333	334	335	
			, {19260, 4, -17, 40}, {19246, -6, -17, 0}, {19246, -8, -17, 0}// 336	337	338	
			, {18736, 0, -11, 45}, {19246, -10, -17, 20}, {18848, -6, -16, 40}// 339	340	341	
			, {19260, -5, -17, 40}, {18866, -3, -16, 40}, {19246, -6, -17, 20}// 342	343	344	
			, {18149, -1, -10, 40}, {18323, 5, -13, 40}, {18620, -2, -10, 45}// 345	346	347	
			, {19246, -3, -17, 20}, {19268, 3, -10, 45}, {19246, -7, -17, 20}// 348	349	350	
			, {19241, 2, -11, 40}, {19220, -1, -17, 0}, {19246, 4, -17, 20}// 351	352	353	
			, {19275, 1, -16, 40}, {19200, -9, -13, 20}, {19090, -3, -16, 8}// 354	355	356	
			, {18850, -4, -16, 40}, {19093, 2, -11, 45}, {19240, 1, -12, 40}// 357	358	360	
			, {19240, 0, -12, 40}, {19240, 2, -12, 40}, {19244, -9, -13, 25}// 361	362	363	
			, {18323, -10, -10, 21}, {19200, -9, -15, 20}, {18056, 0, 6, 45}// 364	365	369	
			, {19286, -1, -7, 40}, {19240, 1, 4, 40}, {18612, -2, -1, 45}// 370	371	372	
			, {18137, -1, -5, 40}, {19242, -2, 6, 40}, {18892, 0, 5, 45}// 373	374	375	
			, {19271, 2, -9, 45}, {19236, -3, 0, 40}, {18159, -1, 6, 45}// 376	378	379	
			, {19237, 3, -1, 40}, {19236, -3, -3, 40}, {19236, -3, -4, 40}// 380	381	382	
			, {19285, 3, -7, 45}, {19260, -10, 5, 20}, {18325, -1, 3, 0}// 383	384	391	
			, {19200, 5, -3, 20}, {19260, 3, -2, 20}, {19200, 2, -3, 20}// 395	396	397	
			, {19260, 4, -2, 20}, {19200, 2, -2, 20}, {19200, 5, -5, 20}// 398	399	400	
			, {19200, 5, -6, 20}, {19200, 2, -6, 20}, {19200, 5, -4, 20}// 401	402	403	
			, {19202, 2, -3, 0}, {19207, 3, -4, 0}, {19207, 4, -4, 0}// 404	406	407	
			, {19207, 3, -5, 5}, {19207, 4, -5, 5}, {19207, 2, -7, 0}// 409	410	412	
			, {19207, 2, -6, 0}, {19207, 3, -7, 0}, {19207, 3, -6, 0}// 413	414	415	
			, {19207, 4, -7, 0}, {19207, 4, -6, 0}, {19236, 2, -3, 40}// 416	417	421	
			, {19207, 2, -6, 5}, {19236, -3, 4, 40}, {19239, 3, 5, 40}// 422	423	424	
			, {19241, -2, 4, 40}, {18657, 2, -5, 45}, {19240, -1, 4, 40}// 425	426	430	
			, {19248, -10, 5, 0}, {19237, 3, -5, 40}, {19240, 0, 4, 40}// 431	433	434	
			, {19205, 4, -6, 15}, {19237, 3, 4, 40}, {19207, 2, -7, 5}// 435	436	437	
			, {19236, 2, -6, 40}, {19236, 2, -5, 40}, {19236, 2, -4, 40}// 438	439	440	
			, {19236, 2, 0, 40}, {19236, 2, 3, 40}, {19241, 1, 5, 40}// 441	442	444	
			, {19241, -2, 5, 40}, {19237, -2, -4, 40}, {19237, -2, -3, 40}// 445	446	447	
			, {19237, -2, -6, 40}, {19237, -2, -5, 40}, {19237, -2, -8, 40}// 448	449	450	
			, {19237, -2, -7, 40}, {18324, -9, 6, 0}, {19237, 3, -9, 40}// 451	452	453	
			, {18606, 3, -3, 45}, {19205, 3, -4, 5}, {19231, 1, 6, 45}// 454	455	456	
			, {19205, 3, -6, 15}, {19236, 2, -7, 40}, {18637, 3, 0, 45}// 457	458	459	
			, {19229, -2, 6, 45}, {19289, 3, -6, 45}, {18659, 2, -4, 45}// 460	461	462	
			, {18054, 2, 2, 45}, {19241, 0, 5, 40}, {19237, -2, 0, 40}// 464	465	466	
			, {18406, 0, 4, 45}, {19241, 2, 5, 40}, {19237, 3, -8, 40}// 467	469	470	
			, {18641, -3, -2, 45}, {18609, -2, -5, 45}, {18894, 2, 5, 45}// 471	472	473	
			, {18614, -2, 4, 45}, {18882, 2, 3, 45}, {19207, 3, -5, 0}// 474	475	476	
			, {19236, -3, -7, 40}, {18085, 2, -2, 45}, {19238, -3, 5, 40}// 477	478	479	
			, {18090, 3, -1, 45}, {19237, -2, 3, 40}, {19236, -3, -1, 40}// 480	481	483	
			, {18639, -3, 2, 45}, {18631, -2, -4, 45}, {18636, 3, 2, 45}// 484	485	486	
			, {18616, 3, -8, 45}, {19236, -3, 3, 40}, {19236, -3, 2, 40}// 487	488	489	
			, {19236, -3, -9, 40}, {19236, -3, -8, 40}, {19237, -2, -9, 40}// 490	491	492	
			, {18618, 3, -4, 45}, {19246, -9, 5, 0}, {19237, -2, 1, 40}// 493	494	495	
			, {18170, 2, 6, 45}, {18087, 2, 0, 45}, {19236, 2, -8, 40}// 496	498	500	
			, {18624, -3, -6, 45}, {19237, -2, 2, 40}, {18324, -8, -6, 40}// 501	502	503	
			, {19237, 3, 0, 40}, {18626, -3, 4, 45}, {19201, 5, -3, 0}// 505	506	508	
			, {19260, 5, -2, 20}, {19207, 4, -5, 0}, {19260, -8, 5, 20}// 509	510	511	
			, {19200, 5, -2, 20}, {19260, -7, 5, 20}, {19260, -6, 5, 20}// 512	513	514	
			, {19260, -5, 5, 20}, {19205, 4, -4, 5}, {19205, 4, -3, 0}// 515	516	517	
			, {19205, 3, -5, 10}, {19207, 4, -7, 5}, {19260, -9, 5, 20}// 519	520	521	
			, {19205, 4, -5, 10}, {19207, 4, -6, 10}, {19200, -5, 6, 20}// 522	523	524	
			, {19207, 3, -6, 10}, {19207, 2, -5, 0}, {19207, 3, -7, 5}// 526	527	530	
			, {18817, -9, -8, 0}, {19241, -1, 5, 40}, {19241, 2, 4, 40}// 532	533	534	
			, {18610, -2, 2, 45}, {19242, 0, 6, 40}, {19236, 2, -2, 40}// 535	536	537	
			, {19236, -3, -6, 40}, {18643, 2, -1, 45}, {19237, 3, 1, 40}// 539	540	541	
			, {18881, 3, 3, 45}, {19205, 3, -3, 0}, {19237, -2, -2, 40}// 542	543	544	
			, {18629, -2, -9, 45}, {19207, 4, -6, 5}, {18109, -8, -9, 40}// 545	546	548	
			, {18101, 2, -7, 45}, {19237, -2, -1, 40}, {18095, 3, 1, 45}// 549	550	551	
			, {18623, -2, -7, 45}, {18632, -3, 0, 45}, {19236, -3, 1, 40}// 552	553	554	
			, {19237, 3, -7, 40}, {19237, 3, 2, 40}, {19237, 3, 3, 40}// 555	556	557	
			, {19236, -3, -5, 40}, {19237, 3, -6, 40}, {19236, -3, -2, 40}// 558	559	560	
			, {19237, 3, -4, 40}, {19237, 3, -3, 40}, {19237, 3, -2, 40}// 561	562	563	
			, {19100, 3, 4, 45}, {19236, 2, -9, 40}, {19239, 2, 6, 40}// 564	566	567	
			, {18323, -10, 0, 21}, {19200, 2, -4, 20}, {18889, 2, 1, 45}// 568	570	571	
			, {19236, 2, -1, 40}, {18058, -1, 4, 45}, {18059, 1, 4, 45}// 572	573	574	
			, {19242, -1, 6, 40}, {19236, 2, 1, 40}, {19236, 2, 2, 40}// 575	576	577	
			, {18821, -10, -5, 0}, {19242, 1, 6, 40}, {19207, 3, -6, 5}// 578	579	582	
			, {19200, 2, -5, 20}, {18817, -7, -3, 0}, {19246, -10, 12, 10}// 583	587	588	
			, {19260, 3, 14, 40}, {19207, -10, 13, 5}, {19201, -9, 16, 5}// 589	590	591	
			, {19196, 2, 14, 20}, {19200, -4, 13, 0}, {19246, -10, 12, 20}// 592	593	594	
			, {19192, 1, 11, 0}, {19205, -10, 17, 0}, {19192, -9, 12, 20}// 595	596	597	
			, {19192, -7, 12, 20}, {19201, -10, 15, 10}, {19260, 2, 11, 40}// 598	599	600	
			, {19204, -9, 15, 5}, {19192, -3, 11, 0}, {19248, 0, 11, 20}// 601	602	603	
			, {19194, -6, 16, 0}, {19193, 4, 14, 40}, {19200, 2, 14, 40}// 604	605	606	
			, {19207, -9, 15, 0}, {19200, 2, 12, 40}, {19205, -10, 16, 5}// 607	608	609	
			, {19192, -7, 12, 0}, {19194, -8, 16, 0}, {19196, 2, 14, 0}// 610	611	612	
			, {19248, -4, 12, 0}, {19196, 5, 14, 0}, {19192, 1, 11, 20}// 613	614	615	
			, {19200, 5, 13, 40}, {19206, 5, 12, 40}, {19248, -6, 12, 0}// 616	617	618	
			, {19204, -8, 16, 0}, {19248, 5, 14, 0}, {19206, -4, 11, 40}// 619	620	621	
			, {19207, -10, 15, 0}, {19189, 4, 14, 20}, {19195, 2, 13, 20}// 622	623	624	
			, {19192, -1, 11, 0}, {18325, -10, 13, 22}, {19196, 2, 12, 0}// 625	626	627	
			, {19248, -2, 11, 0}, {19208, -4, 12, 40}, {19204, -8, 14, 0}// 628	629	630	
			, {19248, -8, 12, 20}, {18323, -3, 7, 0}, {19194, -4, 16, 0}// 631	632	633	
			, {19190, 3, 14, 0}, {19200, 2, 13, 40}, {19192, -3, 11, 20}// 634	635	636	
			, {19260, -2, 11, 40}, {19248, 2, 11, 0}, {19208, 5, 14, 40}// 637	638	639	
			, {19192, -1, 11, 20}, {19204, -9, 13, 5}, {19260, -5, 12, 40}// 640	641	642	
			, {19191, 5, 14, 20}, {19204, -9, 14, 5}, {19248, -6, 12, 20}// 643	644	645	
			, {19207, -9, 16, 0}, {19207, -9, 13, 0}, {19191, 3, 14, 20}// 646	647	648	
			, {19204, -10, 14, 10}, {19207, -10, 14, 5}, {18394, 5, 15, 0}// 649	650	651	
			, {19207, -10, 13, 0}, {19248, 2, 11, 20}, {19194, -7, 16, 0}// 652	653	654	
			, {19192, -5, 12, 0}, {19200, -4, 14, 0}, {19244, -4, 11, 25}// 655	656	658	
			, {19207, -10, 16, 0}, {19248, 0, 11, 0}, {19196, -4, 12, 20}// 659	660	661	
			, {19200, -4, 16, 0}, {19200, -4, 15, 0}, {19192, -9, 12, 0}// 662	663	664	
			, {19260, 0, 11, 40}, {19260, -1, 11, 40}, {19200, 1, 11, 20}// 665	666	667	
			, {19200, -5, 7, 20}, {19200, -5, 8, 20}, {19200, -5, 9, 20}// 668	669	670	
			, {19200, -5, 10, 20}, {19200, -5, 11, 20}, {18325, -1, 12, 0}// 671	672	673	
			, {19244, 5, 12, 20}, {19196, -4, 12, 0}, {19204, -8, 15, 0}// 674	675	676	
			, {19248, -8, 12, 0}, {19260, -10, 12, 40}, {19207, -10, 12, 5}// 677	678	679	
			, {19207, -3, 17, 0}, {19260, -7, 12, 40}, {19260, -8, 12, 40}// 680	681	682	
			, {19205, -9, 17, 0}, {19260, 1, 11, 40}, {19195, 5, 13, 20}// 684	685	686	
			, {19260, -6, 12, 40}, {18814, -5, 17, 6}, {19195, 5, 13, 0}// 687	688	689	
			, {19246, -10, 12, 0}, {19196, 5, 14, 20}, {19196, 2, 12, 20}// 690	691	692	
			, {19260, -9, 12, 40}, {19207, -10, 15, 5}, {19204, -10, 13, 10}// 693	694	695	
			, {19207, -10, 14, 0}, {19192, 4, 14, 0}, {19248, -4, 12, 20}// 696	697	698	
			, {19195, 2, 13, 0}, {19192, -5, 12, 20}, {19204, -8, 13, 0}// 699	700	701	
			, {19201, -8, 17, 0}, {18748, -3, 17, 5}, {19248, -2, 11, 20}// 702	704	705	
			, {19246, -10, 12, 15}, {19260, -3, 11, 40}, {19207, -9, 14, 0}// 706	707	708	
			, {19194, -5, 16, 0}, {19200, 1, 11, 20}, {19200, 1, 12, 20}// 709	710	711	
			, {19200, 1, 13, 20}, {18323, -1, 7, 0}, {19196, 20, -13, 20}// 712	713	714	
			, {18323, 7, -12, 24}, {19197, 20, -10, 20}, {19246, 7, -17, 20}// 715	716	717	
			, {18076, 12, -16, 40}, {19246, 20, -17, 0}, {19260, 13, -17, 40}// 718	719	720	
			, {19281, 13, -16, 40}, {19246, 15, -17, 20}, {19246, 17, -17, 0}// 721	722	723	
			, {19196, 6, -15, 0}, {19196, 6, -14, 0}, {18095, 7, -13, 14}// 724	725	726	
			, {18881, 7, -15, 14}, {19246, 17, -17, 20}, {19198, 6, -12, 0}// 727	728	729	
			, {17692, 10, -16, 40}, {19246, 14, -17, 0}, {19246, 8, -17, 20}// 730	731	732	
			, {19246, 13, -17, 0}, {19246, 8, -17, 0}, {19197, 20, -15, 20}// 733	734	735	
			, {19246, 10, -17, 0}, {18073, 7, -16, 40}, {19199, 20, -15, 40}// 736	737	738	
			, {19200, 20, -16, 40}, {19196, 6, -13, 0}, {19196, 6, -16, 0}// 739	740	741	
			, {19200, 20, -14, 40}, {19197, 20, -15, 0}, {19246, 15, -17, 0}// 742	743	744	
			, {19246, 12, -17, 20}, {19196, 20, -16, 0}, {19246, 20, -17, 20}// 745	746	747	
			, {19197, 20, -10, 0}, {19246, 12, -17, 0}, {19246, 11, -17, 0}// 748	749	750	
			, {19260, 8, -17, 40}, {19246, 6, -17, 0}, {19196, 20, -14, 0}// 751	752	753	
			, {19200, 20, -12, 40}, {19246, 11, -17, 20}, {19196, 20, -13, 0}// 754	755	756	
			, {19200, 6, -13, 20}, {19249, 6, -11, 0}, {19233, 15, -16, 40}// 757	758	759	
			, {19196, 20, -11, 20}, {19199, 20, -10, 40}, {19246, 19, -17, 20}// 761	762	763	
			, {18320, 7, -16, 40}, {18668, 16, -17, 45}, {19246, 14, -17, 20}// 764	765	766	
			, {18094, 7, -15, 10}, {19246, 18, -17, 0}, {19196, 20, -16, 20}// 767	768	769	
			, {19246, 16, -17, 0}, {19246, 7, -17, 0}, {19246, 18, -17, 20}// 770	771	772	
			, {19246, 13, -17, 20}, {19260, 16, -17, 40}, {19244, 6, -13, 25}// 773	774	775	
			, {19200, 20, -13, 40}, {19260, 7, -17, 40}, {19260, 9, -17, 40}// 776	777	778	
			, {19260, 10, -17, 40}, {19260, 11, -17, 40}, {19260, 12, -17, 40}// 779	780	781	
			, {19260, 14, -17, 40}, {19196, 20, -14, 20}, {19200, 6, -15, 20}// 782	783	784	
			, {19260, 6, -13, 20}, {19200, 6, -16, 20}, {19246, 19, -17, 0}// 785	786	787	
			, {19260, 15, -17, 40}, {19200, 20, -11, 40}, {19246, 16, -17, 20}// 788	790	791	
			, {19198, 6, -10, 0}, {19260, 6, -17, 40}, {19196, 20, -12, 20}// 792	793	794	
			, {18325, 7, -13, 40}, {19246, 10, -17, 20}, {19196, 20, -11, 0}// 795	796	797	
			, {19260, 18, -17, 40}, {19260, 17, -17, 40}, {19246, 9, -17, 20}// 798	799	800	
			, {19112, 7, -12, 40}, {19246, 6, -17, 20}, {19260, 19, -17, 40}// 801	802	803	
			, {19195, 20, -12, 0}, {19260, 20, -17, 40}, {19246, 9, -17, 0}// 804	805	806	
			, {19283, 14, -16, 40}, {18325, 7, -12, 0}, {19200, 6, -14, 20}// 807	808	809	
			, {19192, 18, 0, 0}, {19248, 15, 0, 0}, {19248, 9, 0, 0}// 810	811	813	
			, {19246, 12, 0, 0}, {19198, 6, -2, 0}, {19246, 7, 0, 0}// 814	815	816	
			, {19249, 6, -1, 0}, {18325, 7, 1, 0}, {18323, 18, 1, 0}// 817	818	819	
			, {19226, 20, -6, 0}, {19225, 20, -5, 0}, {19200, 20, 6, 40}// 820	821	823	
			, {19196, 20, 0, 20}, {19197, 20, 5, 0}, {19199, 20, 5, 40}// 824	825	826	
			, {19200, 20, 1, 40}, {19200, 20, -7, 40}, {19196, 20, -4, 0}// 827	828	829	
			, {19197, 20, -2, 20}, {19198, 6, -8, 0}, {19249, 6, -3, 0}// 830	831	832	
			, {18325, 13, 1, 0}, {19196, 20, -4, 20}, {19222, 20, -5, 20}// 833	834	835	
			, {19223, 20, -6, 20}, {19224, 20, -7, 20}, {19196, 20, 1, 20}// 836	837	838	
			, {19196, 20, 2, 20}, {19196, 20, 3, 20}, {19196, 20, 4, 20}// 839	840	841	
			, {19197, 20, 5, 20}, {19196, 20, 6, 20}, {18325, 7, -6, 0}// 842	843	844	
			, {19246, 10, 0, 0}, {19192, 8, 0, 0}, {19196, 6, 0, 0}// 845	846	847	
			, {19196, 20, -9, 0}, {19248, 17, 0, 0}, {19200, 14, 6, 20}// 849	850	851	
			, {19196, 20, -8, 20}, {19196, 20, -3, 20}, {19200, 20, -3, 40}// 853	854	855	
			, {18648, 7, -5, 0}, {19200, 20, -6, 40}, {19227, 20, -7, 0}// 856	857	858	
			, {19112, 11, 2, 5}, {19198, 6, -6, 0}, {19246, 13, 0, 0}// 859	860	861	
			, {19199, 20, -2, 40}, {19195, 20, 4, 0}, {19248, 19, 0, 0}// 864	865	866	
			, {19200, 20, 3, 40}, {19249, 6, -7, 0}, {19196, 20, 6, 0}// 867	868	869	
			, {19196, 20, -1, 20}, {19200, 20, 4, 40}, {19200, 20, 0, 40}// 871	872	874	
			, {19192, 16, 0, 0}, {17720, 12, -3, 0}, {19249, 6, -9, 0}// 875	876	877	
			, {19198, 6, -4, 0}, {19249, 6, -5, 0}, {19197, 20, -2, 0}// 880	882	883	
			, {19196, 20, -3, 0}, {19195, 20, 0, 0}, {19196, 20, -1, 0}// 884	885	886	
			, {19112, 13, 2, 0}, {19200, 20, -8, 40}, {19196, 20, -8, 0}// 887	888	890	
			, {19200, 20, -9, 40}, {19200, 20, 2, 40}, {19200, 20, -1, 40}// 891	892	894	
			, {19196, 20, -9, 20}, {19200, 20, -5, 40}, {19200, 20, -4, 40}// 895	897	898	
			, {18323, 11, 1, 0}, {19192, 14, 0, 0}, {19246, 11, 0, 0}// 899	900	901	
			, {18325, 18, 8, 0}, {19196, 15, 8, 0}, {19248, 19, 7, 20}// 902	903	904	
			, {19206, 11, 11, 40}, {19200, 11, 16, 0}, {19248, 15, 11, 20}// 905	906	907	
			, {19248, 13, 11, 0}, {19260, 13, 11, 40}, {19200, 15, 15, 0}// 908	909	910	
			, {19196, 15, 11, 20}, {18703, 11, 10, 0}, {19192, 14, 11, 20}// 911	912	913	
			, {19248, 15, 11, 0}, {19260, 18, 7, 40}, {19260, 19, 7, 40}// 914	915	916	
			, {19260, 6, 12, 40}, {19196, 20, 7, 20}, {19200, 15, 10, 40}// 917	918	919	
			, {19195, 15, 10, 0}, {19208, 11, 12, 40}, {19192, 10, 12, 20}// 920	921	922	
			, {19260, 7, 12, 40}, {19200, 11, 13, 0}, {19192, 6, 12, 20}// 923	924	925	
			, {19248, 9, 12, 20}, {19200, 11, 15, 0}, {19192, 6, 12, 0}// 926	927	928	
			, {19260, 9, 12, 40}, {19192, 8, 12, 0}, {19192, 18, 7, 0}// 929	930	931	
			, {19260, 10, 12, 40}, {19260, 12, 11, 40}, {19200, 11, 14, 0}// 932	933	934	
			, {19196, 11, 12, 20}, {19192, 12, 11, 0}, {19194, 12, 16, 0}// 935	936	937	
			, {19244, 11, 11, 20}, {19192, 12, 11, 20}, {19248, 13, 11, 20}// 938	939	940	
			, {19196, 15, 11, 0}, {19248, 7, 12, 20}, {19195, 15, 9, 20}// 941	942	943	
			, {19200, 15, 14, 0}, {19194, 15, 16, 0}, {19192, 10, 12, 0}// 944	945	946	
			, {19248, 17, 7, 20}, {19260, 14, 11, 40}, {19248, 9, 12, 0}// 947	948	949	
			, {19200, 15, 13, 0}, {19200, 15, 9, 40}, {19248, 7, 12, 0}// 950	951	952	
			, {19208, 15, 11, 40}, {19200, 11, 12, 0}, {19196, 15, 8, 20}// 953	954	955	
			, {19260, 20, 7, 40}, {19260, 17, 7, 40}, {19206, 15, 7, 40}// 956	957	958	
			, {18736, 14, 17, 6}, {19194, 13, 16, 0}, {19195, 15, 10, 20}// 959	960	961	
			, {19196, 11, 12, 5}, {19200, 14, 7, 20}, {19195, 15, 9, 0}// 962	963	964	
			, {19248, 17, 7, 0}, {19192, 16, 7, 20}, {19192, 8, 12, 20}// 965	966	967	
			, {19260, 8, 12, 40}, {19194, 14, 16, 0}, {19200, 15, 12, 0}// 968	969	970	
			, {18802, 9, 10, 0}, {19243, 20, 7, 20}, {19200, 15, 16, 0}// 971	972	973	
			, {19200, 20, 7, 40}, {19196, 20, 7, 0}, {19248, 11, 12, 20}// 974	975	976	
			, {19260, 16, 7, 40}, {19192, 18, 7, 20}, {19243, 20, 7, 0}// 977	978	979	
			, {19192, 14, 11, 0}, {18713, 16, 13, 6}, {19192, 16, 7, 0}// 980	981	982	
			, {19248, 11, 12, 0}, {19248, 19, 7, 0}, {19200, 15, 8, 40}// 983	984	985	
			, {19207, 11, 17, 0}, {18747, 11, 17, 5}, {19244, 15, 7, 20}// 986	987	988	
			, {18325, 7, 13, 0}// 989	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new brianshouseAddonDeed();
			}
		}

		[ Constructable ]
		public brianshouseAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 18819, -5, -10, 0, 1156, -1, "", 1);// 264
			AddComplexComponent( (BaseAddon) this, 18821, -8, -10, 0, 2003, -1, "", 1);// 305
			AddComplexComponent( (BaseAddon) this, 18819, -7, -10, 0, 2003, -1, "", 1);// 359
			AddComplexComponent( (BaseAddon) this, 18821, -6, -10, 0, 1156, -1, "Mirage", 1);// 366
			AddComplexComponent( (BaseAddon) this, 18821, -4, -10, 0, 1157, -1, "", 1);// 367
			AddComplexComponent( (BaseAddon) this, 18819, -3, -10, 0, 1157, -1, "", 1);// 368
			AddComplexComponent( (BaseAddon) this, 18820, -10, -4, 0, 1150, -1, "", 1);// 377
			AddComplexComponent( (BaseAddon) this, 18818, -9, -4, 0, 1150, -1, "", 1);// 385
			AddComplexComponent( (BaseAddon) this, 18821, -10, -7, 0, 1150, -1, "", 1);// 386
			AddComplexComponent( (BaseAddon) this, 19207, 5, -5, 0, 771, -1, "", 1);// 387
			AddComplexComponent( (BaseAddon) this, 19248, -2, 6, 0, 1537, -1, "", 1);// 388
			AddComplexComponent( (BaseAddon) this, 19249, -4, 4, 0, 1537, -1, "", 1);// 389
			AddComplexComponent( (BaseAddon) this, 19249, -4, 6, 0, 1537, -1, "", 1);// 390
			AddComplexComponent( (BaseAddon) this, 19198, -4, 5, 0, 1537, -1, "", 1);// 392
			AddComplexComponent( (BaseAddon) this, 19244, -4, 2, 0, 1537, -1, "", 1);// 393
			AddComplexComponent( (BaseAddon) this, 19207, 2, -7, 15, 771, -1, "", 1);// 394
			AddComplexComponent( (BaseAddon) this, 19207, 2, -4, 0, 771, -1, "", 1);// 405
			AddComplexComponent( (BaseAddon) this, 19207, 5, -4, 0, 771, -1, "", 1);// 408
			AddComplexComponent( (BaseAddon) this, 19207, 5, -5, 5, 771, -1, "", 1);// 411
			AddComplexComponent( (BaseAddon) this, 19207, 5, -7, 0, 771, -1, "", 1);// 418
			AddComplexComponent( (BaseAddon) this, 19207, 5, -6, 0, 771, -1, "", 1);// 419
			AddComplexComponent( (BaseAddon) this, 19207, 2, -7, 10, 771, -1, "", 1);// 420
			AddComplexComponent( (BaseAddon) this, 19207, 5, -6, 10, 771, -1, "", 1);// 427
			AddComplexComponent( (BaseAddon) this, 19207, 5, -6, 5, 771, -1, "", 1);// 428
			AddComplexComponent( (BaseAddon) this, 18818, -9, -6, 0, 1150, -1, "", 1);// 429
			AddComplexComponent( (BaseAddon) this, 18819, -9, -7, 0, 1150, -1, "", 1);// 432
			AddComplexComponent( (BaseAddon) this, 18819, -9, -5, 0, 1150, -1, "", 1);// 443
			AddComplexComponent( (BaseAddon) this, 19207, 2, -6, 10, 771, -1, "", 1);// 463
			AddComplexComponent( (BaseAddon) this, 19207, 4, -7, 10, 771, -1, "", 1);// 468
			AddComplexComponent( (BaseAddon) this, 19192, -3, 2, 0, 1537, -1, "", 1);// 482
			AddComplexComponent( (BaseAddon) this, 19207, 2, -5, 5, 771, -1, "", 1);// 497
			AddComplexComponent( (BaseAddon) this, 19198, -4, 3, 0, 1537, -1, "", 1);// 499
			AddComplexComponent( (BaseAddon) this, 19207, 3, -7, 10, 771, -1, "", 1);// 504
			AddComplexComponent( (BaseAddon) this, 19207, 4, -7, 15, 771, -1, "", 1);// 507
			AddComplexComponent( (BaseAddon) this, 18818, -7, -9, 0, 2003, -1, "", 1);// 518
			AddComplexComponent( (BaseAddon) this, 19207, 5, -7, 10, 771, -1, "", 1);// 525
			AddComplexComponent( (BaseAddon) this, 19207, 3, -7, 15, 771, -1, "", 1);// 528
			AddComplexComponent( (BaseAddon) this, 19192, -3, 6, 0, 1537, -1, "", 1);// 529
			AddComplexComponent( (BaseAddon) this, 18818, -5, -9, 0, 1156, -1, "", 1);// 531
			AddComplexComponent( (BaseAddon) this, 18070, -3, -8, 45, 0, 0, "", 1);// 538
			AddComplexComponent( (BaseAddon) this, 19248, -2, 2, 0, 1537, -1, "", 1);// 547
			AddComplexComponent( (BaseAddon) this, 18820, -10, -6, 0, 1150, -1, "", 1);// 565
			AddComplexComponent( (BaseAddon) this, 18820, -8, -9, 0, 2003, -1, "", 1);// 569
			AddComplexComponent( (BaseAddon) this, 19207, 5, -7, 5, 771, -1, "", 1);// 580
			AddComplexComponent( (BaseAddon) this, 19207, 5, -7, 15, 771, -1, "", 1);// 581
			AddComplexComponent( (BaseAddon) this, 18820, -6, -9, 0, 1156, -1, "", 1);// 584
			AddComplexComponent( (BaseAddon) this, 18818, -3, -9, 0, 1157, -1, "", 1);// 585
			AddComplexComponent( (BaseAddon) this, 18820, -4, -9, 0, 1157, -1, "", 1);// 586
			AddComplexComponent( (BaseAddon) this, 18667, 3, 17, 0, 771, -1, "", 1);// 657
			AddComplexComponent( (BaseAddon) this, 18666, 3, 16, 0, 771, -1, "", 1);// 683
			AddComplexComponent( (BaseAddon) this, 18665, 3, 15, 0, 771, -1, "", 1);// 703
			AddComplexComponent( (BaseAddon) this, 18540, 9, -10, 40, 0, 0, "", 1);// 760
			AddComplexComponent( (BaseAddon) this, 18560, 9, -11, 40, 0, 0, "", 1);// 789
			AddComplexComponent( (BaseAddon) this, 18530, 9, -8, 40, 0, 0, "", 1);// 812
			AddComplexComponent( (BaseAddon) this, 18519, 9, -6, 40, 0, 0, "", 1);// 822
			AddComplexComponent( (BaseAddon) this, 18505, 9, 1, 40, 0, 0, "", 1);// 848
			AddComplexComponent( (BaseAddon) this, 18525, 9, -7, 40, 0, 0, "", 1);// 852
			AddComplexComponent( (BaseAddon) this, 18511, 9, -5, 40, 0, 0, "", 1);// 862
			AddComplexComponent( (BaseAddon) this, 18507, 9, 2, 40, 0, 0, "", 1);// 863
			AddComplexComponent( (BaseAddon) this, 18519, 9, 3, 40, 0, 0, "", 1);// 870
			AddComplexComponent( (BaseAddon) this, 18502, 9, -1, 40, 0, 0, "", 1);// 873
			AddComplexComponent( (BaseAddon) this, 18501, 9, -2, 40, 0, 0, "", 1);// 878
			AddComplexComponent( (BaseAddon) this, 18509, 9, -4, 40, 0, 0, "", 1);// 879
			AddComplexComponent( (BaseAddon) this, 18503, 9, -4, 40, 0, 0, "", 1);// 881
			AddComplexComponent( (BaseAddon) this, 18535, 9, -9, 40, 0, 0, "", 1);// 889
			AddComplexComponent( (BaseAddon) this, 18504, 9, 0, 40, 0, 0, "", 1);// 893
			AddComplexComponent( (BaseAddon) this, 18500, 9, -3, 40, 0, 0, "", 1);// 896

		}

		public brianshouseAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class brianshouseAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new brianshouseAddon();
			}
		}

		[Constructable]
		public brianshouseAddonDeed()
		{
			Name = "brianshouse";
		}

		public brianshouseAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}